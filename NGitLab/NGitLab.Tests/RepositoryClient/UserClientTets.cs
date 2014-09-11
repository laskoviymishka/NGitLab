// -----------------------------------------------------------------------
// <copyright file="UserClientTets.cs"  company="One Call Care Management, Inc.">
// Copyright (c) One Call Care Management, Inc. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NGitLab.Tests.RepositoryClient
{
	using System.Collections.Generic;
	using System.Linq;
	using NGitLab.Models;
	using NUnit.Framework;

	public class UserClientTets
	{
		private readonly IUserClient _userClient;

		public UserClientTets()
		{
			_userClient = _RepositoryClientTests.UserClient;
		}

		[Test]
		public void GetAll()
		{
			List<User> test = _userClient.All.ToList();
			Assert.NotNull(test);
			Assert.IsTrue(test.Count > 20);
		}
	}
}