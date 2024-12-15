using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext context;

        public BookRepository(LibraryContext context)
        {
            this.context = context;
        }

        public async Task Add(Book book)
        {
            await context.Books.AddAsync(book);
        }

        public async Task<bool> Delete(int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book == null) return false;

            context.Books.Remove(book);
            return true;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await context.Books.ToListAsync();
        }

        public async Task<Book?> GetById(int id)
        {
            return await context.Books.FindAsync(id);
        }

        public async Task<bool> Update(Book book)
        {
            var existingBook = await context.Books.FindAsync(book.Id);
            if (existingBook == null) return false;

            context.Entry(existingBook).CurrentValues.SetValues(book);
            return true;
        }
    }
}
