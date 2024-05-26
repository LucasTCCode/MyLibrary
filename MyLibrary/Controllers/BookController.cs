using Microsoft.AspNetCore.Mvc;
using MyLibrary.Application.Common.Interfaces;
using MyLibrary.Domain.Entities;

namespace MyLibrary.Web.Controllers
{
	public class BookController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public BookController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
		{
			_unitOfWork = unitOfWork;
			_webHostEnvironment = webHostEnvironment;
		}
		public IActionResult Index()
		{
			var books = _unitOfWork.Book.GetAll();

			return View(books);
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
				_unitOfWork.Book.Add(obj);
				_unitOfWork.Save();
				TempData["success"] = "The book has been added successfully.";
				return RedirectToAction(nameof(Index));
			}
			TempData["error"] = "The book could not be added.";
			return View(obj);
		}
		public IActionResult Update(int bookId)
		{
			Book? obj = _unitOfWork.Book.Get(u => u.Id == bookId);

			if (obj == null)
			{
				return RedirectToAction("Error", "Home");
			}
			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Update(Book obj)
		{
			if (ModelState.IsValid && obj.Id > 0)
			{
				_unitOfWork.Book.Update(obj);
				_unitOfWork.Save();
				TempData["success"] = "The book has been updated successfully.";
				return RedirectToAction(nameof(Index));
			}
			TempData["error"] = "The book could not be updated.";
			return View(obj);
		}

		public IActionResult Delete(int bookId)
		{
			Book? obj = _unitOfWork.Book.Get(u => u.Id == bookId);


			if (obj == null)
			{
				return RedirectToAction("Error", "Home");
			}
			return View(obj);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(Book obj)
		{
			Book? objFromDb = _unitOfWork.Book.Get(_ => _.Id == obj.Id);
			if (objFromDb is not null)
			{
				_unitOfWork.Book.Remove(objFromDb);
				_unitOfWork.Save();

				TempData["success"] = "The book has been removed successfully.";
				return RedirectToAction(nameof(Index));
			}
			TempData["error"] = "The book could not be removed.";
			return View(obj);
		}
	}
}
