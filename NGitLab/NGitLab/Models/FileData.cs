﻿namespace NGitLab.Models
{
	using System.Runtime.Serialization;

	[DataContract]
	public class FileData
	{
		[DataMember(Name = "blob_id")] public string BlobId;
		[DataMember(Name = "commit_id")] public string CommitId;
		[DataMember(Name = "content")] public string Content;
		[DataMember(Name = "encoding")] public string Encoding;
		[DataMember(Name = "file_name")] public string Name;
		[DataMember(Name = "file_path")] public string Path;
		[DataMember(Name = "ref")] public string Ref;
		[DataMember(Name = "size")] public int Size;
	}
}