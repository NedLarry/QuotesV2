using QuotesApiV2.Domain;
using QuotesApiV2.Domain.Dtos;
using QuotesApiV2.Domain.Models;
using QuotesApiV2.Services.Interfaces;

namespace QuotesApiV2.Services
{
    public class TagService : ITagService
    {
        private readonly QuotesContext _context;

        public TagService(QuotesContext context)
        {
            _context = context;
        }

        public async Task<int> AddTag(CreateTagDto request)
        {
            try
            {
                var newTag = new Tag
                {
                    TagName = request.TagName,
                };

                await _context.Tags.AddAsync(newTag);

                var insertResult = await _context.SaveChangesAsync();

                return insertResult;

            }catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
