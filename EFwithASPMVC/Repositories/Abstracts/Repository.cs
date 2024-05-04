using Application.Data;

namespace Application.Repositories.Abstracts
{
    public class Repository
	{
		protected AcademyDBContext _context { get; set; }

        public Repository(AcademyDBContext context)
        {
            _context=context;
        }
    }
}
