namespace NGitLab.Models
{
	using System.Runtime.Serialization;

	[DataContract]
	public class Branch
	{
		[DataMember(Name = "commit")] public CommitInfo Commit;
		[DataMember(Name = "name")] public string Name;

		[DataMember(Name = "protected")] public bool Protected;
	}
}