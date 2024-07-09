using MyBlogPage.Models;

namespace MyBlogPage.Repositories
{
    public interface IAuthorRepository
    {
        void AddAuthor(AuthorDTO authorDTO);
        void DeleteAuthor(AuthorDTO authorDTO);
        void UpdateAuthor(AuthorDTO authorDTO);
        AuthorDTO GetAuthorById(int id);
        List<AuthorDTO> GetAllAuthor();
    }
}
