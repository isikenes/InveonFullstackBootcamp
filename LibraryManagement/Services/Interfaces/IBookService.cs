using LibraryManagement.Models;

namespace LibraryManagement.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book?> GetById(int id);
        Task Add(Book book);
        Task<bool> Update(Book book);
        Task<bool> Delete(int id);
    }
}
