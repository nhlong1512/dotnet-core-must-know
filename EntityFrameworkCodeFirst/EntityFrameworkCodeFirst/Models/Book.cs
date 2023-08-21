using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCodeFirst.Models
{
    public class Book
    {
        public Guid BookId { get; set; }

        public string Title { get; set; }

        public int TotalPages { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Rating { get; set; }

        public bool? IsDeleted { get; set; }

        public bool? IdPublished { get; set; }
    }
}
