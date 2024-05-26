using MyLibrary.Application.Common.Interfaces;
using MyLibrary.Domain.Entities;
using MyLibrary.Infrastructure.Data;

namespace MyLibrary.Infrastructure.Repository
{
	public class BookRepository : Repository<Book>, IBookRepository
	{
		private readonly ApplicationDbContext _db;


		public BookRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}


		public void Update(Book entity)
		{
			_db.Update(entity);
		}
	}
}
