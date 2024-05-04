using Application.Data;
using Application.Models.Entities.Concretes;
using Application.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories.Concretes
{
	public class StudentRepository : Repository, IRepository<Student>
	{
		public StudentRepository(AcademyDBContext context)
			:base(context)
		{
		}

		public void Create(Student student)
		{
			if (student != null)
			{
				_context.Students.Add(student);
				Save();
			}
		}

		public void Delete(int studentId)
		{
			Student? deletingStudent = _context.Students.FirstOrDefault(s=>s.id==studentId);
			if (deletingStudent != null)
			{
				_context.Students.Remove(deletingStudent);
				Save();
			}
		}

		public IEnumerable<Student> GetAll()
		{
			return _context.Students.ToList();
		}

		public Student GetyByID(int id)
		{
			Student? student = _context.Students.Include(s=>s.Group).FirstOrDefault(s=>s.id==id);
			if (student != null)
			{
				return student;
			}
			return student!;
		}

		public void Save()
		{
			 _context.SaveChanges();
		}

		public void Update(Student student)
		{
			Student? updatingStudent = _context.Students.FirstOrDefault(s=>s.id==student.id);
			if (updatingStudent != null)
			{
				_context.Students.Update(updatingStudent);
				Save();
			}
		}
		
	}
}
