namespace NGitLab
{
	using System.Collections.Generic;
	using NGitLab.Models;

	public interface IUserClient
	{
		IEnumerable<User> All { get; }
		User this[int id] { get; }
		Session Current { get; }
		User Create(UserUpsert user);
		User Update(int id, UserUpsert user);
		void Delete(int id);
	}
}