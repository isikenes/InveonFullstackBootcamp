namespace _3_LibraryAPI.Exceptions
{
    public class BorrowerNotFoundException : Exception
    {
        public BorrowerNotFoundException(int id) : base($"Borrower with id {id} was not found")
        {
        }
    }
}
