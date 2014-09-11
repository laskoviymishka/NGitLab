﻿namespace NGitLab.Impl
{
	using System.Collections.Generic;
	using NGitLab.Models;

	public class ProjectHooksClient : IProjectHooksClient
	{
		private readonly API _api;
		private readonly string _path;

		public ProjectHooksClient(API api, string projectPath)
		{
			_api = api;
			_path = projectPath + "/hooks";
		}

		public IEnumerable<ProjectHook> All
		{
			get { return _api.Get().GetAll<ProjectHook>(_path); }
		}

		public ProjectHook this[int hookId]
		{
			get { return _api.Get().To<ProjectHook>(_path + "/" + hookId); }
		}

		public ProjectHook Create(ProjectHookUpsert hook)
		{
			return _api.Post().With(hook).To<ProjectHook>(_path);
		}

		public ProjectHook Update(int hookId, ProjectHookUpsert hook)
		{
			return _api.Put().With(hook).To<ProjectHook>(_path + "/" + hookId);
		}

		public void Delete(int hookId)
		{
			_api.Delete().To<ProjectHook>(_path + "/" + hookId);
		}
	}
}