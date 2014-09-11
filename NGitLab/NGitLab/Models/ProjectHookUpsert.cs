namespace NGitLab.Models
{
	using System;
	using System.ComponentModel.DataAnnotations;
	using System.Runtime.Serialization;

	[DataContract]
	public class ProjectHookUpsert
	{
		[DataMember(Name = "merge_requests_events")] public bool MergeRequestsEvents;
		[DataMember(Name = "push_events")] public bool PushEvents;
		[Required] [DataMember(Name = "url")] public Uri Url;
	}
}