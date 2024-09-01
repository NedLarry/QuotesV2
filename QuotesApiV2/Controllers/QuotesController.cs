using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesApiV2.Domain.Dtos;
using QuotesApiV2.Services.Interfaces;

namespace QuotesApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Quotes")]

    public class QuotesController : ControllerBase
    {
        private readonly IServiceAgregator _serviceAggregator;

        public QuotesController(IServiceAgregator serviceAggregator)
        {
            _serviceAggregator = serviceAggregator;
        }

        [HttpPost]
        public Task<IActionResult> CreateQuotes(CreateQuoteDto request)
        {
            return _serviceAggregator.CreateQuote(request);
        }

        [HttpGet(":{Id}")]
        public Task<IActionResult> GetQuote(int Id)
        {
            return _serviceAggregator.GetQuote(Id);
        }
    }
}
