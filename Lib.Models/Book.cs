using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Lib.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required(ErrorMessage = "Lütfen kitap adını giriniz.")]
        [DisplayName("Kitap Adı")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen yazar adını giriniz.")]
        [DisplayName("Yazar")]
        public string Author { get; set; }
        [Required(ErrorMessage = "Lütfen resim ekleyiniz.")]
        [DisplayName("Kapak Resmi")]
        public string Image { get; set; }
        [DisplayName("Kütüphane Durumu")]
        public bool IsAvailable { get; set; }

    }
}
