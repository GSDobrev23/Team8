using SchoolLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace SchoolLibrary.ConsoleApp.Controllers;

public class BooksController : Controller
{
    private readonly BookService _service;

    
    public BooksController(BookService service)
    {
        _service = service;
    }

    
    public IActionResult Index()
    {
        var books = _service.GetAllBooks();
        return View(books);
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Borrow(int id)
    {
        TempData["Message"] = _service.BorrowBook(id);
        return RedirectToAction(nameof(Index));
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Return(int id)
    {
        TempData["Message"] = _service.ReturnBook(id);
        return RedirectToAction(nameof(Index));
    }
}