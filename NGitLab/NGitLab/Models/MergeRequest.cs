namespace NGitLab.Models
{
	using System.Runtime.Serialization;

	public class MergeRequest
	{
		public const string Url = "/merge_requests";
		public User Assignee;
		public User Author;
		public bool Closed;

		public int Id;
		public int Iid;
		public bool Merged;

		[DataMember(Name = "project_id")] public int ProjectId;
		[DataMember(Name = "source_branch")] public string SourceBranch;

		[DataMember(Name = "source_project_id")] public int SourceProjectId;
		public string State;
		[DataMember(Name = "target_branch")] public string TargetBranch;
		public string Title;
	}
}