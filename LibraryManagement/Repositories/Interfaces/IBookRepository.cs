using LibraryManagement.Models;

namespace LibraryManagement.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book?> GetById(int id);
        Task Add(Book book);
        Task<bool> Update(Book book);
        Task<bool> Delete(int id);
    }
}
