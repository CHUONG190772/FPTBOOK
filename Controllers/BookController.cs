using FPTLibrary.Data;
using FPTLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FPTLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext context;
        public BookController(ApplicationDbContext _context)
        {
            context = _context;
        }
        public IActionResult Index(int? id)
        {
            var book = context.Books.ToList();        
            return View(book);
        }
        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = context.Books
                .Include(c => c.Category)
                .FirstOrDefault(m => m.Id == id);
            return View(book);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                context.Books.Update(book);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = context.Books.Find(id);
            context.Books.Remove(book);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Index(string BookSearch)
        {
            ViewData["GetBook"] = BookSearch;
            var query = from item in context.Books select item;
            if (!string.IsNullOrEmpty(BookSearch))
            {
                query = query.Where(b => b.Name.Contains(BookSearch));
            }
            return View(await query.AsNoTracking().ToListAsync());
        }
    }
}
