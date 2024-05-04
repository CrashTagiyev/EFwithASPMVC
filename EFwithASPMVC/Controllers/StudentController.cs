using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Application.Data;
using Application.Models.Entities.Concretes;
using Application.Repositories.Abstracts;
using Application.ViewModels.StudentViewModels;

namespace Application.Controllers
{
	public class StudentController : Controller
	{
		private readonly IRepository<Student> _repository;

		public StudentController(IRepository<Student> repository)
		{
			_repository = repository;
            
        }

		// GET: Students
		[HttpGet]
		public IActionResult AllStudents()
		{
			List<StudentVM> students = new();
			foreach (Student student in _repository.GetAll().ToList())
			{
				students.Add(new()
				{
					ID = student.id,
					FirstName = student.FirstName,
					LastName = student.LastName,
					Email = student.Email,
					GroupId = student.GroupId,
				});
			}
			return View(students);
		}

		public async Task<IActionResult> Details(int id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var student = _repository.GetyByID(id);
			if (student == null)
			{
				return NotFound();
			}
			StudentVM studentDeail = new()
			{
				ID = student.id,
				FirstName = student.FirstName,
				LastName = student.LastName,
				Email = student.Email,
				GroupId = student.GroupId
			};
			return View(studentDeail);
		}

		public IActionResult Create()
		{
            return View();
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(StudentVM student)
		{
			if (ModelState.IsValid)
			{
				Student newStudent = new()
				{
					FirstName = student.FirstName,
					LastName = student.LastName,
					Email = student.Email,
					GroupId = student.GroupId
				};
				_repository.Create(newStudent);

				return RedirectToAction("AllStudents");
			}
			return View();
		}

		// GET: Students/Edit/5
		public IActionResult Edit(int id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var student = _repository.GetyByID(id);
			if (student == null)
			{
				return NotFound();
			}
			StudentVM updatingStudent = new()
			{
				ID = student.id,
				FirstName = student.FirstName,
				LastName = student.LastName,
				Email = student.Email,
				GroupId = student.GroupId
			};
			return View(updatingStudent);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(StudentVM student)
		{
			if (student == null)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				var updatingStudent = _repository.GetyByID(student.ID);
				updatingStudent.FirstName = student?.FirstName;
				updatingStudent.LastName = student?.LastName;
				updatingStudent.Email = student?.Email;
				updatingStudent.GroupId = student!.GroupId;
				_repository.Update(updatingStudent);
			}

			return RedirectToAction("AllStudents");
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int id)
		{
			if (id != null)
			{
				_repository.Delete(id);
			}

			return RedirectToAction("AllStudents");
		}

		
	}
}
