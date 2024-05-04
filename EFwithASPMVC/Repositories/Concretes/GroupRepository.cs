using Application.Data;
using Application.Models.Entities.Concretes;
using Application.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;
namespace Application.Repositories.Concretes
{
	public class GroupRepository : IRepository<Group>
	{
		private AcademyDBContext _context { get; set; }

		public GroupRepository(AcademyDBContext context)
		{
			_context = context;
		}
		public void Create(Group group)
		{
			if (group != null)
			{
				_context.Groups.Add(group);
				Save();
			}
		}

		public void Delete(int groupId)
		{
			Group? deletingGroup = _context.Groups.Find(groupId);
			if (deletingGroup != null)
			{
				_context.Remove(deletingGroup);
				Save();
			}
		}

		public IEnumerable<Group> GetAll()
		{
			return _context.Groups.Include(g => g.Students).ToList();
		}

		public Group GetyByID(int id)
		{
			Group? group = _context.Groups.Include(g => g.Students).FirstOrDefault(g => g.id == id);
			if (group != null)
			{
				return group;
			}
			return group!;
		}


		public void Update(Group group)
		{
			Group? updatingGroup = _context.Groups.Find(group.id);
			if (updatingGroup != null)
			{
				_context.Groups.Update(updatingGroup);
				Save();
			}
		}
		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
