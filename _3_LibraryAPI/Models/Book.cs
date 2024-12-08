using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace _3_LibraryAPI.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Author { get; set; }

        public int? BorrowerId { get; set; }

        [ForeignKey("BorrowerId")]
        [JsonIgnore]
        public Borrower? Borrower { get; set; }
    }
}
