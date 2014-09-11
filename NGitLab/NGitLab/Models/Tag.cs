namespace NGitLab.Models
{
	using System.Runtime.Serialization;

	[DataContract]
	public class Tag
	{
		[DataMember(Name = "commit")] public CommitInfo Commit;
		[DataMember(Name = "name")] public string Name;
	}
}