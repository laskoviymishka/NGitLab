namespace NGitLab.Models
{
	using System.Runtime.Serialization;

	[DataContract]
	public class PersonInfo
	{
		[DataMember(Name = "email")] public string Email;
		[DataMember(Name = "name")] public string Name;
	}
}