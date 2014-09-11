// -----------------------------------------------------------------------
// <copyright file="INotesClient.cs"  company="One Call Care Management, Inc.">
// Copyright (c) One Call Care Management, Inc. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace NGitLab
{
	using System.Collections.Generic;
	using NGitLab.Models;

	public interface INotesClient
	{
		IEnumerable<Note> All { get; }
		Note this[int id] { get; }

		void Create(string noteBody);
	}
}