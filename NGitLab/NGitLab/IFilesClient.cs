namespace NGitLab
{
	using NGitLab.Models;

	public interface IFilesClient
	{
		void Create(FileUpsert file);
		void Update(FileUpsert file);
		void Delete(FileDelete file);
	}
}