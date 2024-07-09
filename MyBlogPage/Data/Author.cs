using System.ComponentModel.DataAnnotations;

namespace MyBlogPage.Data
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
