using Application.Models.Entities.Concretes;
using Application.Repositories.Abstracts;
using Application.ViewModels.GroupViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
	public class GroupController : Controller
	{
		private IRepository<Group> _repository;
		public GroupController(IRepository<Group> repository)
		{
			_repository = repository;
			ViewBag.Groups=_repository.GetAll().Select(g=>g.id).ToList();
		}

		[HttpGet]
		public IActionResult AllGroups()
		{
			List<AllGroupsVM> allGroups = new();
			foreach (Group group in _repository.GetAll())
			{
				allGroups.Add(new()
				{
					Id = group.id,
					Name = group.Name,
					Description = group.Description,
					Students = group.Students!.ToList()
				});
			}

			return View(allGroups);
		}

		[HttpGet]
		public IActionResult CreateGroup()
		{
			return View();
		}


		public IActionResult CreateGroup(CrreateGroupVM newGroupVM)
		{
			if (newGroupVM != null)
			{
				Group newGroup = new Group() { Name = newGroupVM.Name, Description = newGroupVM.Description };
				_repository.Create(newGroup);
			}
			return RedirectToAction("AllGroups");
		}


		public IActionResult ReadGroup(int id)
		{
			Group group = _repository.GetyByID(id);
			if (group is not null)
			{
				ReadGroupVM readGroup = new()
				{
					Id = group.id,
					Name = group.Name,
					Description = group.Description,
					Students = new()
				};
				foreach (Student student in group.Students)
				{
					readGroup.Students.Add(
						new()
						{
							ID = student.id,
							FirstName = student.FirstName,
							LastName = student.LastName,
							Email = student.Email,
							GroupId = student.id,
						}
						);
				}
				return View(readGroup);
			}
			return RedirectToAction("AllGroups");
		}


		[HttpGet]
		public IActionResult EditGroup(int id)
		{
			EditGroupVM changingGroup = new()
			{
				Id = id,
			};
			return View(changingGroup);
		}
		[HttpPost]
		public IActionResult EditGroup(EditGroupVM changedGroup)
		{
			if (changedGroup != null)
			{
				Group updatingGroup = _repository.GetyByID(changedGroup.Id);
				if (updatingGroup != null)
				{
					updatingGroup.Name = changedGroup.Name;
					updatingGroup.Description = changedGroup.Description;
					_repository.Update(updatingGroup);
				}
			}
			return RedirectToAction("AllGroups");
		}
		public IActionResult DeleteGroup(int id)
		{
			_repository.Delete(id);
			return RedirectToAction("AllGroups");
		}
	}
}
