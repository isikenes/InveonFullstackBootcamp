namespace _3_LibraryAPI.Exceptions
{
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException(int id) : base($"Book with id {id} was not found")
        {
        }
    }
}
