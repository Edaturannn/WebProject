using System.ComponentModel.DataAnnotations;

namespace WebAPI.Entity.Concrete;

public class Comment
{
    [Key]
    public Guid CommentId { get; set; }
    public string? Content { get; set; }


    public Guid? PostId { get; set; }
    public Post? Post { get; set; }

    public DateTime DateTime { get; set; } = DateTime.UtcNow;

}