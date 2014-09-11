namespace NGitLab.Tests.RepositoryClient
{
	using System.Linq;
	using NGitLab.Models;
	using NUnit.Framework;

	public class BranchClientTests
	{
		private readonly IBranchClient _branches;

		public BranchClientTests()
		{
			_branches = _RepositoryClientTests.RepositoryClient.Branches;
		}

		[Test]
		public void GetAll()
		{
			CollectionAssert.IsNotEmpty(_branches.All.ToArray());
		}

		[Test]
		public void GetByName()
		{
			Branch branch = _branches["master"];
			Assert.IsNotNull(branch);
			Assert.IsNotNull(branch.Name);
		}
	}
}