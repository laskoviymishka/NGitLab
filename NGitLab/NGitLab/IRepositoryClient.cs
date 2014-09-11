namespace NGitLab
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using NGitLab.Models;

	public interface IRepositoryClient
	{
		IEnumerable<Tag> Tags { get; }
		IEnumerable<TreeOrBlob> Tree { get; }

		IEnumerable<Commit> Commits { get; }

		IFilesClient Files { get; }

		IBranchClient Branches { get; }

		IIssuesClient Issues { get; }

		IMilestoneClient Milestones { get; }

		IProjectHooksClient ProjectHooks { get; }
		void GetRawBlob(string sha, Action<Stream> parser);
		SingleCommit GetCommit(Sha1 sha);
		IEnumerable<Diff> GetCommitDiff(Sha1 sha);
	}
}