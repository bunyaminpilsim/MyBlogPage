using MyBlogPage.Data;
using MyBlogPage.Models;

namespace MyBlogPage.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }
        public void AddAuthor(AuthorDTO authorDTO)
        {
            Author author = new Author
            {
                Name = authorDTO.Name
            };
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void DeleteAuthor(AuthorDTO authorDTO)
        {
            var existingAuthor = _context.Authors.FirstOrDefault(c => c.Id == authorDTO.Id);
            if (existingAuthor != null)
            {
                _context.Authors.Remove(existingAuthor);
                _context.SaveChanges();
            }
        }

        public List<AuthorDTO> GetAllAuthor()
        {
            List<Author> authors = _context.Authors.ToList();

            var authorDTOs = new List<AuthorDTO>();
            foreach (var author in authors)
            {
                authorDTOs.Add(new AuthorDTO
                {
                    Id = author.Id,
                    Name = author.Name,
                });
            }

            return authorDTOs;
        }

        public AuthorDTO GetAuthorById(int id)
        {
            var author = _context.Authors.FirstOrDefault(c => c.Id == id);
            if (author == null) return null;

            return new AuthorDTO
            {
                Id = author.Id,
                Name = author.Name,
            };
        }

        public void UpdateAuthor(AuthorDTO authorDTO)
        {
            var existingAuthor = _context.Categories.FirstOrDefault(c => c.Id == authorDTO.Id);
            if (existingAuthor != null)
            {
                existingAuthor.Name = authorDTO.Name;
                _context.SaveChanges();
            }
        }
    }
}
