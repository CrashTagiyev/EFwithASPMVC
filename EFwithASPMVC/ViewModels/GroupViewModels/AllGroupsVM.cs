using Application.Models.Entities.Concretes;

namespace Application.ViewModels.GroupViewModels
{
	public class AllGroupsVM
	{
		public int Id { get; set; }	
		public string? Name { get; set; }
		public string? Description { get; set; }
		public List<Student>? Students { get; set; }
	}
}
