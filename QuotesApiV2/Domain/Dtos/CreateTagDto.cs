using System.ComponentModel.DataAnnotations;

namespace QuotesApiV2.Domain.Dtos
{
    public class CreateTagDto
    {
        [Required]
        [MaxLength(10)]
        public string TagName { get; set; } = null!;
    }
}
