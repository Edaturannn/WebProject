using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entity.Concrete;

public class Author
{
    [Key]
    public Guid AuthorId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }

    public List<Post>? Posts { get; set; }

    public DateTime DateTime { get; set; } = DateTime.UtcNow;
}