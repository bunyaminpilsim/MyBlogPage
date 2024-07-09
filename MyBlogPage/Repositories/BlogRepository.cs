using MyBlogPage.Data;
using MyBlogPage.Models;

namespace MyBlogPage.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly DataContext _context;
        public BlogRepository(DataContext context)
        {
            _context = context;
        }
        public void AddBlog(BlogDTO blogDTO)
        {
            Blog blog = new Blog
            {
                Summary = blogDTO.Summary,
                AuthorId = blogDTO.AuthorId,
                CategoryID = blogDTO.CategoryID,
                Content = blogDTO.Content,
                Date = blogDTO.Date,
                Title = blogDTO.Title
            };
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }

        public void DeleteBlog(BlogDTO blogDTO)
        {
            var existingBlog = _context.Blogs.FirstOrDefault(c => c.Id == blogDTO.Id);
            if (existingBlog != null)
            {
                _context.Blogs.Remove(existingBlog);
                _context.SaveChanges();
            }
        }

        public List<BlogDTO> GetAllBlog()
        {
            List<Blog> blogs = _context.Blogs.ToList();

            var blogDTOs = new List<BlogDTO>();
            foreach (var blog in blogs)
            {
                blogDTOs.Add(new BlogDTO
                {
                    Id = blog.Id,
                    Title = blog.Title,
                    Date = blog.Date,
                    AuthorId = blog.AuthorId,
                    CategoryID = blog.CategoryID,
                    Content = blog.Content,
                    Summary = blog.Summary
                });
            }

            return blogDTOs;
        }

        public BlogDTO GetBlogById(int id)
        {
            var blog = _context.Blogs.FirstOrDefault(c => c.Id == id);
            if (blog == null) return null;

            return new BlogDTO
            {
                Id = blog.Id,
                Summary = blog.Summary,
                AuthorId = blog.AuthorId,
                Content = blog.Content,
                CategoryID = blog.CategoryID,
                Date = blog.Date,
                Title = blog.Title
            };
        }

        public void UpdateBlog(BlogDTO blogDTO)
        {
            var existingBlog = _context.Blogs.FirstOrDefault(c => c.Id == blogDTO.Id);
            if (existingBlog != null)
            {
                existingBlog.Summary = blogDTO.Summary;
                existingBlog.AuthorId = blogDTO.AuthorId;
                existingBlog.CategoryID = blogDTO.CategoryID;
                existingBlog.Content = blogDTO.Content;
                existingBlog.Date = blogDTO.Date;
                existingBlog.Title= blogDTO.Title;
                _context.SaveChanges();
            }
        }
    }
}
