using MyBlogPage.Models;

namespace MyBlogPage.Repositories
{
    public interface IBlogRepository
    {
        void AddBlog(BlogDTO blogDTO);
        void UpdateBlog(BlogDTO blogDTO);
        void DeleteBlog(BlogDTO blogDTO);
        BlogDTO GetBlogById(int id);
        List<BlogDTO> GetAllBlog();
    }
}
