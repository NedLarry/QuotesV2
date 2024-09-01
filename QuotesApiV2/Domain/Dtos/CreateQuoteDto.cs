using System.ComponentModel.DataAnnotations;

namespace QuotesApiV2.Domain.Dtos
{
    public class CreateQuoteDto
    {
        [Required]
        [MaxLength(300)]
        public string Content { get; set; } = null!;

        public string Author { get; set; } = null!;

        public List<string> Tags { get; set; } = new List<string>();
    }
}
