using _3_LibraryAPI.Models;
using _3_LibraryAPI.Utilities;

namespace _3_LibraryAPI.Services.Interfaces
{
    public interface IBorrowerService
    {
        IEnumerable<Borrower> GetAll();
        IEnumerable<Borrower> GetAllPaged(PagingParameters pagingParameters);
        Borrower GetById(int id);
        void Add(Borrower borrower);
        bool Update(Borrower borrower);
        bool Delete(int id);
        bool BorrowBook(int borrowerId, int bookId);
        bool ReturnBook(int borrowerId, int bookId);
    }
}
