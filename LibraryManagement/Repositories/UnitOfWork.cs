using LibraryManagement.Data;
using LibraryManagement.Repositories.Interfaces;

namespace LibraryManagement.Repositories
{
    public class UnitOfWork(LibraryContext context) : IUnitOfWork
    {
        private IBookRepository _bookRepository;

        public IBookRepository BookRepository
        {
            get
            {
                if (_bookRepository == null)
                {
                    _bookRepository = new BookRepository(context);
                }
                return _bookRepository;
            }
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }


    }
}
