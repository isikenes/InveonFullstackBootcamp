using _3_LibraryAPI.Models;
using _3_LibraryAPI.Repositories.Interfaces;
using _3_LibraryAPI.Services.Interfaces;
using _3_LibraryAPI.Utilities;

namespace _3_LibraryAPI.Services
{
    public class BookService(IBookRepository bookRepository) : IBookService
    {
        public void Add(Book book)
        {
            bookRepository.Add(book);
        }

        public bool Delete(int id)
        {
            return bookRepository.Delete(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return bookRepository.GetAll();
        }

        public IEnumerable<Book> GetAllPaged(PagingParameters pagingParameters)
        {
            return bookRepository.GetAllPaged(pagingParameters);
        }

        public Book GetById(int id)
        {
            return bookRepository.GetById(id);
        }

        public bool Update(Book book)
        {
            return bookRepository.Update(book);
        }
    }
}
