using _3_LibraryAPI.Models;
using _3_LibraryAPI.Repositories.Interfaces;
using _3_LibraryAPI.Services.Interfaces;
using _3_LibraryAPI.Utilities;

namespace _3_LibraryAPI.Services
{
    public class BorrowerService(IBorrowerRepository borrowerRepository, IBookRepository bookRepository) : IBorrowerService
    {
        public void Add(Borrower borrower)
        {
            borrowerRepository.Add(borrower);
        }

        public bool BorrowBook(int borrowerId, int bookId)
        {
            var borrower = borrowerRepository.GetById(borrowerId);
            var book = bookRepository.GetById(bookId);

            if (borrower == null || book == null || book.BorrowerId != null)
            {
                return false;
            }

            book.BorrowerId = borrowerId;
            return bookRepository.Update(book);
        }

        public bool Delete(int id)
        {
            return borrowerRepository.Delete(id);
        }

        public IEnumerable<Borrower> GetAll()
        {
            return borrowerRepository.GetAll();
        }

        public IEnumerable<Borrower> GetAllPaged(PagingParameters pagingParameters)
        {
            return borrowerRepository.GetAllPaged(pagingParameters);
        }

        public Borrower GetById(int id)
        {
            return borrowerRepository.GetById(id);
        }


        public bool ReturnBook(int borrowerId, int bookId)
        {
            var book = bookRepository.GetById(bookId);

            if (book == null || book.BorrowerId != borrowerId)
            {
                return false;
            }

            book.BorrowerId = null;
            return bookRepository.Update(book);
        }

        public bool Update(Borrower borrower)
        {
            return borrowerRepository.Update(borrower);
        }
    }
}
