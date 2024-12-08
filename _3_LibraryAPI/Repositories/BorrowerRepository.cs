using _3_LibraryAPI.Data;
using _3_LibraryAPI.Models;
using _3_LibraryAPI.Repositories.Interfaces;
using _3_LibraryAPI.Utilities;
using Microsoft.EntityFrameworkCore;

namespace _3_LibraryAPI.Repositories
{
    public class BorrowerRepository : IBorrowerRepository
    {
        private readonly LibraryContext _context;

        public BorrowerRepository(LibraryContext context)
        {
            _context = context;
        }

        public void Add(Borrower borrower)
        {
            _context.Borrowers.Add(borrower);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var borrower = _context.Borrowers.Find(id);
            if (borrower == null) return false;

            _context.Borrowers.Remove(borrower);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Borrower> GetAll()
        {
            return _context.Borrowers.Include(b => b.BorrowedBooks).ToList();
        }

        public IEnumerable<Borrower> GetAllPaged(PagingParameters pagingParameters)
        {
            return _context.Borrowers
                .Include(b => b.BorrowedBooks)
                .Skip(pagingParameters.Skip)
                .Take(pagingParameters.PageSize)
                .ToList();
        }

        public Borrower GetById(int id)
        {
            return _context.Borrowers
                .Include(b => b.BorrowedBooks)
                .FirstOrDefault(b => b.Id == id);
        }

        public bool Update(Borrower borrower)
        {
            var existing = _context.Borrowers.Find(borrower.Id);
            if (existing == null) return false;

            existing.Name = borrower.Name;
            _context.SaveChanges();
            return true;
        }
    }
}
