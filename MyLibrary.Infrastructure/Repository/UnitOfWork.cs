using MyLibrary.Application.Common.Interfaces;
using MyLibrary.Infrastructure.Data;

namespace MyLibrary.Infrastructure.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDbContext _db;
		public IBookRepository Book { get; private set; }
		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			Book = new BookRepository(db);
		}

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
