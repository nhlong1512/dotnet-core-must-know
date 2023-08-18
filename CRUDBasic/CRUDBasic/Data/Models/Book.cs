using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDBasic.Data.Models;

[Table("Book")]
public partial class Book
{
    [Key]
    [Column("BookID")]
    public Guid BookId { get; set; }

    public string? Title { get; set; }

    public int? TotalPages { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Rating { get; set; }

    public bool? IsDeleted { get; set; }

    public bool? IsPublished { get; set; }
}
