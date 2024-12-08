using _3_LibraryAPI.Models;
using _3_LibraryAPI.Utilities;

namespace _3_LibraryAPI.Services.Interfaces
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetAllPaged(PagingParameters pagingParameters);
        Book GetById(int id);
        void Add(Book book);
        bool Update(Book book);
        bool Delete(int id);
    }
}
