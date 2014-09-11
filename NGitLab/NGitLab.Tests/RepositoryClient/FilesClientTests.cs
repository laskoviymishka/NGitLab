namespace NGitLab.Tests.RepositoryClient
{
	using NGitLab.Models;

	public class FilesClientTests
	{
		private readonly IFilesClient _client;
		private FileData[] _files;

		public FilesClientTests()
		{
			_client = _RepositoryClientTests.RepositoryClient.Files;
		}
	}
}