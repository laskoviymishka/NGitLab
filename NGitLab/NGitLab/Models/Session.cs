namespace NGitLab.Models
{
	using System.Runtime.Serialization;

	[DataContract]
	public class Session : User
	{
		public new const string Url = "/session";

		[DataMember(Name = "private_token")] public string PrivateToken;
	}
}