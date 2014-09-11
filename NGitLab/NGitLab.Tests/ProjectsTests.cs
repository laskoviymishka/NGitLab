﻿namespace NGitLab.Tests
{
	using System;
	using System.Linq;
	using NGitLab.Models;
	using NUnit.Framework;

	public class ProjectsTests : IDisposable
	{
		private readonly Project _created;
		private readonly IProjectClient _projects;

		public ProjectsTests()
		{
			_projects = Config.Connect().Projects;
			CreateProject(out _created, "default");
		}

		public void Dispose()
		{
			_projects.Delete(_created.Id);
		}

		[Test]
		public void GetAllProjects()
		{
			Project[] projects = _projects.All.ToArray();

			CollectionAssert.IsNotEmpty(projects);
		}

		[Test]
		public void GetOwnedProjects()
		{
			Project[] projects = _projects.Owned.ToArray();

			CollectionAssert.IsNotEmpty(projects);
		}

		[Test]
		public void GetAccessibleProjects()
		{
			Project[] projects = _projects.Accessible.ToArray();

			CollectionAssert.IsNotEmpty(projects);
		}

		[Test]
		public void CreateDelete()
		{
			Project created;
			ProjectCreate p = CreateProject(out created, "test2");

			Assert.AreEqual(p.Description, created.Description);
			Assert.AreEqual(p.IssuesEnabled, created.IssuesEnabled);
			Assert.AreEqual(p.MergeRequestsEnabled, created.MergeRequestsEnabled);
			Assert.AreEqual(p.Name, created.Name);

			_projects.Delete(created.Id);
		}

		private ProjectCreate CreateProject(out Project created, string name)
		{
			var p = new ProjectCreate
			{
				Description = "desc",
				ImportUrl = null,
				IssuesEnabled = true,
				MergeRequestsEnabled = true,
				Name = name,
				NamespaceId = null,
				SnippetsEnabled = true,
				VisibilityLevel = VisibilityLevel.Public,
				WallEnabled = true,
				WikiEnabled = true
			};

			created = _projects.Create(p);
			return p;
		}
	}
}