using MyBlogPage.Models;
using System.ComponentModel.DataAnnotations;

namespace MyBlogPage.Data
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int CategoryID { get; set; }
        public DateTime? Date { get; set; }
    }
}
