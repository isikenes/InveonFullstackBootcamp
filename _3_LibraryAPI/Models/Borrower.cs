using System.ComponentModel.DataAnnotations;

namespace _3_LibraryAPI.Models
{
    public class Borrower
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        public ICollection<Book>? BorrowedBooks { get; set; }
    }
}
