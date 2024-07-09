namespace MyBlogPage.Models
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<BlogDTO>? blogs { get; set; }
    }
}
