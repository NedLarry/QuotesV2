using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuotesApiV2.Domain.Dtos;
using QuotesApiV2.Services.Interfaces;

namespace QuotesApiV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Tags("Tags")]
    public class TagsController : ControllerBase
    {
        private readonly IServiceAgregator _serviceAggregator;

        public TagsController(IServiceAgregator serviceAggregator)
        {
            _serviceAggregator = serviceAggregator;
        }

        [HttpPost]
        public Task<IActionResult> CreateTag(CreateTagDto request)
        {
            return _serviceAggregator.CreateTag(request);
        }

        [HttpGet]
        public Task<IActionResult> GetAllTags()
        {
            return _serviceAggregator.GetAllTags();
        }
    }
}
