// -----------------------------------------------------------------------
// <copyright file="NotesClient.cs"  company="One Call Care Management, Inc.">
// Copyright (c) One Call Care Management, Inc. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NGitLab.Impl
{
	using System.Collections.Generic;
	using NGitLab.Models;

	public class NotesClient : INotesClient
	{
		private readonly API _api;
		private readonly string _notesPath;

		public NotesClient(string notesPath, API api)
		{
			_api = api;
			_notesPath = notesPath;
		}

		public IEnumerable<Note> All
		{
			get { return _api.Get().GetAll<Note>(_notesPath); }
		}

		public Note this[int id]
		{
			get { return _api.Get().To<Note>(_notesPath + "/" + id); }
		}

		public void Create(string noteBody)
		{
			var note = new Note
			{
				Body = noteBody
			};

			_api.Post().With(note).Stream(_notesPath, s => { });
		}
	}
}