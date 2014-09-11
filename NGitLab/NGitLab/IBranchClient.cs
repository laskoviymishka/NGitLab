namespace NGitLab
{
	using System.Collections.Generic;
	using NGitLab.Models;

	public interface IBranchClient
	{
		IEnumerable<Branch> All { get; }
		Branch this[string name] { get; }
		Branch Protect(string name);
		Branch Unprotect(string name);
		Branch Create(BranchCreate branch);
	}
}