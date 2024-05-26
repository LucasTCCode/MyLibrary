using MyLibrary.Domain.Entities;
using System.Linq.Expressions;

namespace MyLibrary.Application.Common.Interfaces
{
	public interface IBookRepository
	{
	void Update(Book entity);
	}
}
