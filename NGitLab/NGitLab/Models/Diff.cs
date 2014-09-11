﻿namespace NGitLab.Models
{
	using System.Runtime.Serialization;

	[DataContract]
	public class Diff
	{
		[DataMember(Name = "a_mode")] public string AMode;

		[DataMember(Name = "b_mode")] public string BMode;
		[DataMember(Name = "diff")] public string Difference;
		[DataMember(Name = "deleted_file")] public bool IsDeletedFile;

		[DataMember(Name = "new_file")] public bool IsNewFile;

		[DataMember(Name = "renamed_file")] public bool IsRenamedFile;
		[DataMember(Name = "new_path")] public string NewPath;

		[DataMember(Name = "old_path")] public string OldPath;
	}
}