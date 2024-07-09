namespace MyBlogPage.Models
{
    public class BlogDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int CategoryID { get; set; }
        public AuthorDTO? Author { get; set; }
        public CategoryDTO? Category { get; set; }
        public DateTime? Date { get; set; }


    }
}
