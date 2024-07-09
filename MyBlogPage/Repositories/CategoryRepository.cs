using MyBlogPage.Data;
using MyBlogPage.Models;

namespace MyBlogPage.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public void AddCategory(CategoryDTO categoryDTO)
        {
            Category category = new Category
            {
                Name = categoryDTO.Name,
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(CategoryDTO categoryDTO)
        {
            var existingCategory = _context.Categories.FirstOrDefault(c => c.Id == categoryDTO.Id);
            if (existingCategory != null)
            {
                _context.Categories.Remove(existingCategory);
                _context.SaveChanges();
            }
        }

        public List<CategoryDTO> GetAllCategories()
        {
            List<Category> categories = _context.Categories.ToList();

            var categoryDTOs = new List<CategoryDTO>();
            foreach (var category in categories)
            {
                categoryDTOs.Add(new CategoryDTO
                {
                    Id = category.Id,
                    Name = category.Name,
                });
            }

            return categoryDTOs;
        }

        public CategoryDTO GetCategoryById(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null) return null;

            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public void UpdateCategory(CategoryDTO categoryDTO)
        {
            var existingCategory = _context.Categories.FirstOrDefault(c => c.Id == categoryDTO.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = categoryDTO.Name;
                _context.SaveChanges();
            }
        }
    }
}
