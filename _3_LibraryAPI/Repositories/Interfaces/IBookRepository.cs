using _3_LibraryAPI.Models;
using _3_LibraryAPI.Utilities;

namespace _3_LibraryAPI.Repositories.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetAllPaged(PagingParameters pagingParameters);
        Book GetById(int id);
        void Add(Book book);
        bool Update(Book book);
        bool Delete(int id);
    }
}
