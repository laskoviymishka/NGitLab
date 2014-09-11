namespace NGitLab.Models
{
	using System.Runtime.Serialization;

	[DataContract]
	public class BranchCreate
	{
		[DataMember(Name = "branch_name")] public string Name;

		[DataMember(Name = "ref")] public string Ref;
	}
}