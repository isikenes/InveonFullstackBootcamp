using _3_LibraryAPI.Models;
using _3_LibraryAPI.Utilities;

namespace _3_LibraryAPI.Repositories.Interfaces
{
    public interface IBorrowerRepository
    {
        IEnumerable<Borrower> GetAll();
        IEnumerable<Borrower> GetAllPaged(PagingParameters pagingParameters);
        Borrower GetById(int id);
        void Add(Borrower borrower);
        bool Update(Borrower borrower);
        bool Delete(int id);

    }
}
