namespace MyLibrary.Application.Common.Interfaces
{
	public interface IUnitOfWork
	{
		IBookRepository Book { get; }
		void Save();
	}
}
