﻿namespace NGitLab.Tests.RepositoryClient
{
	using System;
	using System.Linq;
	using NGitLab.Models;
	using NUnit.Framework;

	public class ProjectHooksClientTests
	{
		private readonly IProjectHooksClient _hooks;

		public ProjectHooksClientTests()
		{
			_hooks = _RepositoryClientTests.RepositoryClient.ProjectHooks;
		}

		[Test]
		public void GetAll()
		{
			CollectionAssert.IsEmpty(_hooks.All.ToArray());
		}

		[Test]
		public void CreateUpdateDelete()
		{
			var toCreate = new ProjectHookUpsert
			{
				MergeRequestsEvents = true,
				PushEvents = true,
				Url = new Uri("http://scooletz.com"),
			};

			ProjectHook created = _hooks.Create(toCreate);
			ThereIsOneHook();

			Assert.AreEqual(toCreate.MergeRequestsEvents, created.MergeRequestsEvents);
			Assert.AreEqual(toCreate.PushEvents, created.PushEvents);
			Assert.AreEqual(toCreate.Url, created.Url);

			var toUpdate = new ProjectHookUpsert
			{
				MergeRequestsEvents = false,
				PushEvents = false,
				Url = new Uri("http://git.scooletz.com"),
			};

			ProjectHook updated = _hooks.Update(created.Id, toUpdate);

			ThereIsOneHook();

			Assert.AreEqual(toUpdate.MergeRequestsEvents, updated.MergeRequestsEvents);
			Assert.AreEqual(toUpdate.PushEvents, updated.PushEvents);
			Assert.AreEqual(toUpdate.Url, updated.Url);

			_hooks.Delete(updated.Id);

			ThereIsNoHook();
		}

		private void ThereIsOneHook()
		{
			Assert.AreEqual(1, _hooks.All.ToArray().Length);
		}

		private void ThereIsNoHook()
		{
			CollectionAssert.IsEmpty(_hooks.All.ToArray());
		}
	}
}