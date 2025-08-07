using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entity.Concrete;

public class Post
{
    [Key]
    public Guid PostId { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }

    public Guid? AuthorId { get; set; }
    public Author? Author { get; set; }

    public List<Comment>? Comments { get; set; }
    public DateTime DateTime { get; set; } = DateTime.UtcNow;
}