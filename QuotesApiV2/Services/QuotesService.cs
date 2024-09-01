using Microsoft.EntityFrameworkCore.ChangeTracking;
using QuotesApiV2.Domain;
using QuotesApiV2.Domain.Dtos;
using QuotesApiV2.Domain.Models;
using QuotesApiV2.Services.Interfaces;

namespace QuotesApiV2.Services
{
    public class QuotesService : IQuotesService
    {

        private readonly QuotesContext _context;

        public QuotesService(QuotesContext context)
        {
            _context = context;
        }
        public async Task<int> AddQuote(CreateQuoteDto request)
        {
            try
            {

                var quoteTags = string.Empty;

                foreach (var tag in request.Tags)
                {
                    quoteTags = string.Join(',', tag);
                }

                var newQuotes = new Quote
                {
                    Content = request.Content,
                    Author = request.Author,
                    Tags = quoteTags
                };

                await _context.Quotes.AddAsync(newQuotes);

                var insertResult = await _context.SaveChangesAsync();

                return insertResult;

            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
