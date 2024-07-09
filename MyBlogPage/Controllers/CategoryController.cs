using Microsoft.AspNetCore.Mvc;
using MyBlogPage.Models;
using MyBlogPage.Repositories;

namespace MyBlogPage.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(CategoryDTO category)
        {

            if (ModelState.IsValid)
            {
                _categoryRepository.AddCategory(category);
                return RedirectToAction("CategoryList");
            }

            return View(category);
        }

        public IActionResult CategoryList()
        {
            var category = _categoryRepository.GetAllCategories();
            return View(category);
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id)
        {
            var category = _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult UpdateCategory(CategoryDTO category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.UpdateCategory(category);
                return RedirectToAction("CategoryList");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult DeleteCategory(int id)
        {

            var category = _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryRepository.DeleteCategory(category);
            return RedirectToAction("CategoryList");
        }
    }
}
