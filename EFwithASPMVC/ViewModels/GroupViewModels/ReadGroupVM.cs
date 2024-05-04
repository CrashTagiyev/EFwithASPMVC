using Application.Models.Entities.Concretes;
using Application.ViewModels.StudentViewModels;

namespace Application.ViewModels.GroupViewModels
{
	public class ReadGroupVM
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }
		public List<StudentVM>? Students { get; set; }
	}
}
