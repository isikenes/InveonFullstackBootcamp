using LibraryManagement.Models;
using LibraryManagement.Repositories.Interfaces;
using LibraryManagement.Services.Interfaces;

namespace LibraryManagement.Services
{
    public class BookService(IUnitOfWork unitOfWork) : IBookService
    {
        public async Task Add(Book book)
        {
            await unitOfWork.BookRepository.Add(book);
            await unitOfWork.Save();
        }

        public async Task<bool> Delete(int id)
        {
            var result = await unitOfWork.BookRepository.Delete(id);
            if (result) await unitOfWork.Save();

            return result;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await unitOfWork.BookRepository.GetAll();
        }

        public async Task<Book?> GetById(int id)
        {
            return await unitOfWork.BookRepository.GetById(id);
        }

        public async Task<bool> Update(Book book)
        {
            var result = await unitOfWork.BookRepository.Update(book);
            if (result) await unitOfWork.Save();

            return result;
        }
    }
}
