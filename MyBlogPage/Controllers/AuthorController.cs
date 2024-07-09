using Microsoft.AspNetCore.Mvc;
using MyBlogPage.Models;
using MyBlogPage.Repositories;

namespace MyBlogPage.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAuthor(AuthorDTO author)
        {

            if (ModelState.IsValid)
            {
                _authorRepository.AddAuthor(author);
                return RedirectToAction("AuthorList");
            }

            return View(author);
        }

        public IActionResult AuthorList()
        {
            var author = _authorRepository.GetAllAuthor();
            return View(author);
        }

        [HttpGet]
        public IActionResult UpdateAuthor(int id)
        {
            var author = _authorRepository.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        public IActionResult UpdateAuthor(AuthorDTO author)
        {
            if (ModelState.IsValid)
            {
                _authorRepository.UpdateAuthor(author);
                return RedirectToAction("AuthorList");
            }
            return View(author);
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {

            var author = _authorRepository.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            _authorRepository.DeleteAuthor(author);
            return RedirectToAction("AuthorList");
        }
    }
}
