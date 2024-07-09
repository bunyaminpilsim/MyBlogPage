using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlogPage.Data;
using MyBlogPage.Models;
using MyBlogPage.Repositories;

namespace MyBlogPage.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;

        public BlogController(IBlogRepository blogRepository, ICategoryRepository categoryRepository, IAuthorRepository authorRepository)
        {
            _blogRepository = blogRepository;
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;   
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            ViewBag.Categories = _categoryRepository.GetAllCategories();
            ViewBag.Author = _authorRepository.GetAllAuthor();

            return View();
        }

        [HttpPost]
        public IActionResult AddBlog(BlogDTO blogDTO)
        {
            if (ModelState.IsValid)
            {
                blogDTO.Date= DateTime.Now;

                blogDTO.Category = _categoryRepository.GetCategoryById(blogDTO.CategoryID);
                blogDTO.Author = _authorRepository.GetAuthorById(blogDTO.AuthorId);
                _blogRepository.AddBlog(blogDTO);
                return RedirectToAction("BlogList");
            }
            return View(blogDTO);
        }
        public IActionResult BlogList()
        {
           
            ViewBag.Categories = _categoryRepository.GetAllCategories();
            ViewBag.Author = _authorRepository.GetAllAuthor();
            var blogs = _blogRepository.GetAllBlog();
            return View(blogs);
        }
        public IActionResult GetALlBlogs()
        {
            ViewBag.CategoryName = _categoryRepository.GetAllCategories().ToDictionary(c=>c.Id,c=>c.Name);
            ViewBag.AuthorName = _authorRepository.GetAllAuthor().ToDictionary(a=>a.Id,a=>a.Name);
            var blogs = _blogRepository.GetAllBlog();

            var authorPostCounts = blogs
                .GroupBy(b => b.AuthorId)
                .Select(g => new { AuthorId = g.Key, PostCount = g.Count() })
                .ToDictionary(a => a.AuthorId, a => a.PostCount);


            var categoryCounts = blogs
                .GroupBy(b => b.CategoryID)
                .Select(g => new { CategoryID = g.Key, PostCount = g.Count() })
                .ToDictionary(a => a.CategoryID, a => a.PostCount);

            ViewBag.CategoryCounts = categoryCounts;
            ViewBag.AuthorPostCounts = authorPostCounts;
            ViewBag.AuthorPostCounts = authorPostCounts;
            ViewBag.Categories = _categoryRepository.GetAllCategories();
            ViewBag.Author = _authorRepository.GetAllAuthor();
            return View(blogs);
        }

        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            ViewBag.Categories = _categoryRepository.GetAllCategories();
            ViewBag.Author = _authorRepository.GetAllAuthor();
            var blog = _blogRepository.GetBlogById(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        [HttpPost]
        public IActionResult UpdateBlog(BlogDTO blogDTO)
        {
            if (ModelState.IsValid)
            {
                blogDTO.Date = DateTime.Now;
                _blogRepository.UpdateBlog(blogDTO);
                return RedirectToAction("BlogList");
            }
            return View(blogDTO);
        }

        [HttpGet]
        public IActionResult DeleteBlog(int id)
        {

            var blog = _blogRepository.GetBlogById(id);
            if (blog == null)
            {
                return NotFound();
            }
            _blogRepository.DeleteBlog(blog);
            return RedirectToAction("BlogList");
        }
    }
}
