namespace NGitLab.Tests.RepositoryClient
{
	using NGitLab.Models;
	using NUnit.Framework;

	[SetUpFixture]
// ReSharper disable InconsistentNaming
	public class _RepositoryClientTests
// ReSharper restore InconsistentNaming
	{
		public static IRepositoryClient RepositoryClient;
		public static IUserClient UserClient;
		private Project _project;

		[SetUp]
		public void SetUp()
		{
			RepositoryClient = Config.Connect().GetRepository(3767);
			UserClient = Config.Connect().Users;
		}

		[TearDown]
		public void TearDown()
		{
		}
	}
}