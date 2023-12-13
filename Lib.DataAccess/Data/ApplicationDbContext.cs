using Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BorrowedBook> BorrowedBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Name = "Otomatik Portakal", Author = "Anthony Burgess", Image = "https://i.dr.com.tr/cache/600x600-0/originals/0001806049001-1.jpg", IsAvailable = true });
        }
    }
}
