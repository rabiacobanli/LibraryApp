using Lib.DataAccess.Repository.IRepository;
using LibraryApp.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IBookRepository Book { get; private set; }
        public IBorrowedBooks BorrowedBooks { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Book = new BookRepository(_db);
            BorrowedBooks=new BorrowedBookRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
