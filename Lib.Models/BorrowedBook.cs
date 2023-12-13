using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lib.Models
{
    public class BorrowedBook
    {
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        [Required(ErrorMessage = "Lütfen ödünç alanın adını giriniz.")]
        [DisplayName("Ödünç Alan Adı")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lütfen ödünç alanın soyadını giriniz.")]
        [DisplayName("Ödünç Alan Soyadı")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "Lütfen geri getirme tarihini giriniz.")]
        [DisplayName("Geri Getirme Tarihi")]

        public DateTime ReturnDate { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}
