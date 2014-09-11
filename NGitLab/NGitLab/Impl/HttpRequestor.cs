﻿namespace NGitLab.Impl
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Net;

	public class HttpRequestor
	{
		private readonly MethodType _method; // Default to GET requests
		private readonly API _root;
		private object _data;

		public HttpRequestor(API root, MethodType method)
		{
			_root = root;
			_method = method;
		}

		public HttpRequestor With(object data)
		{
			_data = data;
			return this;
		}

		public T To<T>(string tailAPIUrl)
		{
			T result = default(T);
			Stream(tailAPIUrl, s => result = SimpleJson.DeserializeObject<T>(new StreamReader(s).ReadToEnd()));
			return result;
		}

		public void Stream(string tailAPIUrl, Action<Stream> parser)
		{
			WebRequest req = SetupConnection(_root.GetAPIUrl(tailAPIUrl));

			if (HasOutput())
			{
				SubmitData(req);
			}
			else if (_method == MethodType.Put)
			{
				req.Headers.Add("Content-Length", "0");
			}

			using (WebResponse response = req.GetResponse())
			{
				using (Stream stream = response.GetResponseStream())
				{
					parser(stream);
				}
			}
		}

		public IEnumerable<T> GetAll<T>(string tailUrl)
		{
			return new Enumerable<T>(_root.APIToken, _root.GetAPIUrl(tailUrl));
		}

		private void SubmitData(WebRequest request)
		{
			request.ContentType = "application/json";

			using (var writer = new StreamWriter(request.GetRequestStream()))
			{
				writer.Write(SimpleJson.SerializeObject(_data));
				writer.Flush();
				writer.Close();
			}
		}

		private bool HasOutput()
		{
			return _method == MethodType.Post || _method == MethodType.Put && _data != null;
		}

		private WebRequest SetupConnection(Uri url)
		{
			return SetupConnection(url, _method);
		}

		private static WebRequest SetupConnection(Uri url, MethodType methodType)
		{
			WebRequest request = WebRequest.Create(url);
			request.Method = methodType.ToString().ToUpperInvariant();
			request.Headers.Add("Accept-Encoding", "gzip");

			return request;
		}

		private class Enumerable<T> : IEnumerable<T>
		{
			private readonly string _apiToken;
			private readonly Uri _startUrl;

			public Enumerable(string apiToken, Uri startUrl)
			{
				_apiToken = apiToken;
				_startUrl = startUrl;
			}

			public IEnumerator<T> GetEnumerator()
			{
				return new Enumerator<T>(_apiToken, _startUrl);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			private class Enumerator<T> : IEnumerator<T>
			{
				private readonly string _apiToken;
				private readonly List<T> _buffer = new List<T>();

				private bool _finished;
				private Uri _nextUrlToLoad;

				public Enumerator(string apiToken, Uri startUrl)
				{
					_apiToken = apiToken;
					_nextUrlToLoad = startUrl;
				}

				public void Dispose()
				{
				}

				public bool MoveNext()
				{
					if (_buffer.Count == 0)
					{
						if (_nextUrlToLoad == null)
						{
							return false;
						}

						WebRequest request = SetupConnection(_nextUrlToLoad, MethodType.Get);
						request.Headers["PRIVATE-TOKEN"] = _apiToken;

						using (WebResponse response = request.GetResponse())
						{
							// <http://localhost:1080/api/v3/projects?page=2&per_page=0>; rel="next", <http://localhost:1080/api/v3/projects?page=1&per_page=0>; rel="first", <http://localhost:1080/api/v3/projects?page=2&per_page=0>; rel="last"
							string link = response.Headers["Link"];

							string[] nextLink = null;
							if (string.IsNullOrEmpty(link) == false)
								nextLink = link.Split(',')
									.Select(l => l.Split(';'))
									.FirstOrDefault(pair => pair[1].Contains("next"));

							if (nextLink != null)
							{
								_nextUrlToLoad = new Uri(nextLink[0].Trim('<', '>', ' '));
							}
							else
							{
								_nextUrlToLoad = null;
							}

							Stream stream = response.GetResponseStream();
							_buffer.AddRange(SimpleJson.DeserializeObject<T[]>(new StreamReader(stream).ReadToEnd()));
						}

						return _buffer.Count > 0;
					}

					if (_buffer.Count > 0)
					{
						_buffer.RemoveAt(0);
						return (_buffer.Count > 0) ? true : MoveNext();
					}

					return false;
				}

				public void Reset()
				{
					throw new NotImplementedException();
				}

				public T Current
				{
					get { return _buffer[0]; }
				}

				object IEnumerator.Current
				{
					get { return Current; }
				}
			}
		}
	}
}