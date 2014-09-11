namespace NGitLab
{
	using NGitLab.Impl;

	public class GitLabClient
	{
		public readonly IProjectClient Projects;
		public readonly IUserClient Users;
		private readonly API _api;

		private GitLabClient(string hostUrl, string apiToken)
		{
			_api = new API(hostUrl, apiToken);
			Users = new UserClient(_api);
			Projects = new ProjectClient(_api);
		}

		public static GitLabClient Connect(string hostUrl, string apiToken)
		{
			return new GitLabClient(hostUrl, apiToken);
		}

		public IRepositoryClient GetRepository(int projectId)
		{
			return new RepositoryClient(_api, projectId);
		}
	}
}