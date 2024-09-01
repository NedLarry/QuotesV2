using QuotesApiV2.Domain.Dtos;
using QuotesApiV2.Domain.Models;

namespace QuotesApiV2.Services.Interfaces
{
    public interface IQuotesService
    {
        Task<int> AddQuote(CreateQuoteDto request);

        Task<Quote> GetQuote(int Id);

        Task<List<Quote>> GetQuotes();

        //TODO: Return random quote
    }
}
