using MyBlogPage.Models;

namespace MyBlogPage.Repositories
{
    public interface ICategoryRepository
    {
        void AddCategory(CategoryDTO categoryDTO);
        void UpdateCategory(CategoryDTO categoryDTO);
        void DeleteCategory(CategoryDTO categoryDTO);
        CategoryDTO GetCategoryById(int id);
        List<CategoryDTO> GetAllCategories();

    }
}
