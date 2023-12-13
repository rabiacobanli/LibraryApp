using Lib.DataAccess.Repository.IRepository;
using Lib.Models;
using LibraryApp.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DataAccess.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private ApplicationDbContext _db;
        public BookRepository(ApplicationDbContext db) : base(db)
        {
             _db=db;
        }
       
    }
}
