﻿namespace NGitLab
{
	using System.Collections.Generic;
	using NGitLab.Models;

	public interface IProjectHooksClient
	{
		IEnumerable<ProjectHook> All { get; }
		ProjectHook this[int hookId] { get; }
		ProjectHook Create(ProjectHookUpsert hook);
		ProjectHook Update(int hookId, ProjectHookUpsert hook);
		void Delete(int hookId);
	}
}