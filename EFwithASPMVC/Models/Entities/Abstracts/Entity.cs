namespace Application.Models.Entities.Abstracts
{
	public class Entity
	{
		public int id { get; set; }
		public DateTime CreatedTime { get; set; } = DateTime.Now;
		public DateTime UpdatedTime { get; set; } = DateTime.Now;
	}
}
