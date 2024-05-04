using Application.Models.Entities.Abstracts;
using Application.Models.Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Abstracts
{
	public interface IRepository<T> where T : Entity,new()
	{
		IEnumerable<T> GetAll();
		void Create(T entity);
		T GetyByID(int id);
		void Update(T entity);
		void Delete(int entityId);
		void Save();
	}
}
