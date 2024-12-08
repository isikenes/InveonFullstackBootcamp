using _3_LibraryAPI.Data;
using _3_LibraryAPI.Models;
using _3_LibraryAPI.Repositories.Interfaces;
using _3_LibraryAPI.Utilities;
using Microsoft.EntityFrameworkCore;

namespace _3_LibraryAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.Include(b => b.Borrower).ToList();
        }

        public IEnumerable<Book> GetAllPaged(PagingParameters pagingParameters)
        {
            return _context.Books
                .Include(b => b.Borrower)
                .Skip(pagingParameters.Skip)
                .Take(pagingParameters.PageSize)
                .ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.Include(b => b.Borrower).FirstOrDefault(b => b.Id == id);
        }

        public bool Update(Book book)
        {
            var existing = _context.Books.Find(book.Id);
            if (existing == null) return false;

            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.BorrowerId = book.BorrowerId;

            _context.SaveChanges();
            return true;
        }
    }
}
