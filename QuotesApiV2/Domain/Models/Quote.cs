using System.ComponentModel.DataAnnotations;

namespace QuotesApiV2.Domain.Models
{
    public class Quote : BaseEntity
    {
        [MaxLength(250)]
        public string Content { get; set; } = null!;

        [MaxLength(20)]
        public string Author { get; set; } = null!;

        [MaxLength(40)]
        public string Tags { get; set; } = null!;
    }
}
