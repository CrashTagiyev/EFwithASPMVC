using Application.Models.Entities.Abstracts;

namespace Application.Models.Entities.Concretes
{
	public class Group:Entity
	{
		public string? Name { get; set; }
		public string? Description { get; set; }


		//Navigation property
		public ICollection<Student>? Students { get; set; } 
	}
}
