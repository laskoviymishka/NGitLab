// -----------------------------------------------------------------------
// <copyright file="IssuesClientTests.cs"  company="One Call Care Management, Inc.">
// Copyright (c) One Call Care Management, Inc. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NGitLab.Tests.RepositoryClient
{
	using System.Collections.Generic;
	using System.Linq;
	using NGitLab.Models;
	using NUnit.Framework;

	public class IssuesClientTests
	{
		private readonly IIssuesClient _issuesClient;

		public IssuesClientTests()
		{
			_issuesClient = _RepositoryClientTests.RepositoryClient.Issues;
		}

		[Test]
		public void GetAll()
		{
			List<Issue> test = _issuesClient.All.ToList();
			Assert.NotNull(test);
		}


		[Test]
		public void CreateMany()
		{
			for (int i = 0; i < 100; i++)
			{
				_issuesClient.Create(new Issue
				{
					Title = "test created" + i,
					Labels = new[] {"test", "test1"}
				});
			}
		}

		[Test]
		public void CheckMany()
		{
			List<Issue> issues = _issuesClient.All.ToList();
			Assert.IsTrue(issues.Count > 100);
		}

		[Test]
		public void Create()
		{
			int initialCount = _issuesClient.All.Count();
			_issuesClient.Create(new Issue
			{
				Title = "test created",
				Labels = new[] {"test", "test1"}
			});

			int afterCreateCount = _issuesClient.All.Count();
			Assert.IsTrue(initialCount < afterCreateCount);
			Assert.IsTrue(initialCount + 1 == afterCreateCount);
		}

		[Test]
		public void Update()
		{
			Issue issue = _issuesClient.All.Last();
			string initialDescription = issue.Description;
			IEnumerable<string> initialLabels = issue.Labels;
			issue.Description = initialDescription + "added";
			issue.Labels = new[] {"test", "test1"};
			_issuesClient.Update(issue);
			Issue updatedIssue = _issuesClient.All.Last();
			Assert.IsTrue(initialDescription != updatedIssue.Description);
			Assert.IsTrue(updatedIssue.Description.Contains("added"));
			Assert.IsTrue(updatedIssue.Labels.Count() == 2);
			updatedIssue.Description = initialDescription;
			_issuesClient.Update(issue);
		}
	}
}