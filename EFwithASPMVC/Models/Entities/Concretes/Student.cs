using Application.Models.Entities.Abstracts;


namespace Application.Models.Entities.Concretes
{
	public class Student:Entity
	{
		public string? FirstName { get; set;}
		public string? LastName { get; set;}
		public string? Email { get; set;}

		//Foreign key
		public int GroupId { get; set; }

		//Navigation property
		public Group Group { get; set; }	
	}
}
