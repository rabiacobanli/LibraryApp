using Lib.DataAccess.Repository.IRepository;
using Lib.Models;
using LibraryApp.DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Book> bookList = _unitOfWork.Book.GetAll().ToList();
            return View(bookList);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Book obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Book.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Kitap başarılı bir şekilde eklendi.";
                return RedirectToAction("Index");
            }
            return View(obj);    
           
        }
        public IActionResult Borrow()
        {
           return View();
        }

        [HttpPost]
        public IActionResult Borrow(int? id,BorrowedBook obj)
        {
            Book? book = _unitOfWork.Book.Get(b => b.BookId == id);
           
            if (book != null)
            {
                if (ModelState.IsValid)
                {
                    if (book.IsAvailable)
                    {
                        var borrowedBooks = new BorrowedBook
                        {
                            BookId = book.BookId,
                            FirstName = obj.FirstName,
                            LastName = obj.LastName,
                            ReturnDate = obj.ReturnDate
                        };

                        book.IsAvailable = false;
                        _unitOfWork.Book.Add(obj);
                        
                        _unitOfWork.Save();

                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Kitap zaten ödünç alınmış.");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Kitap bulunamadı.");
            }

            return View(obj);
        }
        //    if (ModelState.IsValid)
        //    {
        //        if (book.IsAvailable)
        //        {
        //            BorrowedBook borrowedBooks = new BorrowedBook
        //            {
        //                BookId = book.BookId,
        //                FirstName = obj.FirstName,
        //                LastName = obj.LastName,
        //                ReturnDate = obj.ReturnDate
        //            };

        //            book.IsAvailable = false;

        //            _unitOfWork.Book.Add(book);
        //        _unitOfWork.Book.Borrow(obj);


        //            _unitOfWork.Save();

        //            return RedirectToAction(nameof(Index));
        //        }
        //    }

        //    //return View(p);
        //}
    }
    //public IActionResult Borrow(int? id)
    //{
    //    if (id == null || id == 0)
    //    {
    //        return NotFound();
    //    }
    //    var bookFromDb = _db.BorrowedBooks.FirstOrDefault(b => b.Id == id);
    //    if (bookFromDb == null)
    //    {
    //        return NotFound();
    //    }
    //    return View(bookFromDb);

    //}
    //[HttpPost]
    //public IActionResult Borrow(BorrowedBook obj)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        _db.BorrowedBooks.Add(obj);
    //        _db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }
    //    return View(obj);
    //}
}

