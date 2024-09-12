using Core.Contracts;
using Core.Models;
using CW20.Models;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using System.Diagnostics;

namespace CW20.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAuthorRepo _authorRepo;

        private readonly IBookService _bookService;
        public HomeController(ILogger<HomeController> logger,IBookService bookService,IAuthorRepo authorRepo)
        {
            _logger = logger;
            _authorRepo = authorRepo;
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
           var Authors = new List<Author>();
           Authors.Add(await _authorRepo.GetById(2));

            var book = new Book() { Name = "bookName30", IsExpert = true, Price = 555, CategoryId = 1, Authors = Authors };
          
            await _bookService.AddBook(book);
            return Json(new {});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
