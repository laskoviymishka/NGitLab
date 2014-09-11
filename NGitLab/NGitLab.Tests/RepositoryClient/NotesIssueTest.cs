// -----------------------------------------------------------------------
// <copyright file="NotesIssueTest.cs"  company="One Call Care Management, Inc.">
// Copyright (c) One Call Care Management, Inc. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NGitLab.Tests.RepositoryClient
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using NGitLab.Models;
	using NUnit.Framework;

	public class NotesIssueTest
	{
		private readonly INotesClient _notesClient;


		public NotesIssueTest()
		{
			Issue issue = _RepositoryClientTests.RepositoryClient.Issues.All.First();
			_notesClient = _RepositoryClientTests.RepositoryClient.Issues.Notes(issue);
		}

		[Test]
		public void CreateTest()
		{
			_notesClient.Create("test");
		}

		[Test]
		public void All()
		{
			List<Note> notes = _notesClient.All.ToList();
			Debug.Assert(notes.Count > 50);
		}
	}
}