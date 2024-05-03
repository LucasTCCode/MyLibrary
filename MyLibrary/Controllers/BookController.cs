using Microsoft.AspNetCore.Mvc;
using MyLibrary.Domain.Entities;
using MyLibrary.Infrastructure.Data;

namespace MyLibrary.Web.Controllers
{
	public class BookController : Controller
	{
		private readonly ApplicationDbContext _db;

		public BookController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			var books = _db.Books.ToList();

			return View();
		}

		//GET
		public IActionResult Create()
		{
			return View();
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Book obj)
		{
			if (obj.Title == obj.Description)
			{
				ModelState.AddModelError("Title", "The description cannot match the title");
			}

			if (obj.CurrentPage > obj.Pages)
			{
				ModelState.AddModelError("CurrentPage", "The current page cannot be higher than the amount of pages in the book.");
			}

			if (ModelState.IsValid)
			{
				_db.Books.Add(obj);
				_db.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(obj);
		}
		public IActionResult Update(int villaId)
		{
			Book? obj = _db.Books.FirstOrDefault(_ => _.Id == villaId);

			if (obj == null)
			{
				return NotFound();
			}

			return View(villaId);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(Book obj)
		{
			if (obj.CurrentPage > obj.Pages)
			{
				ModelState.AddModelError("CurrentPage", "The current page cannot be higher than the amount of pages in the book.");
			}

			if (ModelState.IsValid && obj.Id > 0)
			{
				_db.Books.Update(obj);
				_db.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			return View(obj);
		}
		public IActionResult Delete(int villaId)
		{
			Book? obj = _db.Books.FirstOrDefault(_ => _.Id == villaId);

			if (obj == null)
			{
				return RedirectToAction("Error", "Home");
			}

			return View(villaId);
		}

		[HttpPost]
		public IActionResult Delete(Book obj)
		{
			Book? objFromDb = _db.Books.FirstOrDefault(_ => _.Id == obj.Id);

			if (objFromDb is not null)
			{
				_db.Books.Remove(obj);
				_db.SaveChanges();

				TempData["success"] = "The book has been deleted successfully.";

				return RedirectToAction(nameof(Index));
			}

			TempData["error"] = "The book cannot be deleted.";
			return View(obj);
		}
	}
}
