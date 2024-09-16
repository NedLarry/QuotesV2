using Azure.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using QuotesApiV2.Domain.Dtos;
using QuotesApiV2.Domain.Models;
using QuotesApiV2.Services.Interfaces;
using System.Security.Cryptography;

namespace QuotesApiV2.Services
{
    [NonController]
    public class ServiceAggregator : ControllerBase, IServiceAgregator
    {
        private readonly IQuotesService _quotesService;
        private readonly ITagService _tagService;
        public ServiceAggregator(IQuotesService quotesService, ITagService tagService)
        {
            _quotesService = quotesService;
            _tagService = tagService;
        }

        public async Task<IActionResult> CreateQuote(CreateQuoteDto request)
        {
            try
            {

                if (request.Tags.Count > 3)
                {
                    return BadRequest(new ApiResponse
                    {
                        responseCode = "01",
                        responseMessage = "Quotes are allowed three tags only",
                        data = request
                        
                    });
                }

                var quotesCreated = await _quotesService.AddQuote(request);

                if ( quotesCreated < 0 || quotesCreated == -1)
                {
                    return BadRequest(new ApiResponse
                    {
                        responseCode = "01",
                        responseMessage = "Error creating quotes. Try again",
                        data= request
                    });
                }

                return Ok(new ApiResponse
                {
                    responseCode = "00",
                    responseMessage = "Success",
                    data = quotesCreated
                });

            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse
                {
                    responseCode = "99",
                    responseMessage = ex.Message,
                    data = request
                });
            }
        }

        public async Task<IActionResult> CreateTag(CreateTagDto request)
        {
            try
            {
                var TagCreated = await _tagService.AddTag(request);

                if (TagCreated < 0 || TagCreated == -1)
                {
                    return BadRequest(new ApiResponse
                    {
                        responseCode = "01",
                        responseMessage = "Error creating Tag. Try again",
                        data = request
                    });
                }

                return Ok(new ApiResponse
                {
                    responseCode = "00",
                    responseMessage = "Success",
                    data = TagCreated
                });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse
                {
                    responseCode = "99",
                    responseMessage = ex.Message,
                    data = request
                });
            }
        }

        public async Task<IActionResult> GetAllQuotes()
        {
            try
            {
                var tags = await _quotesService.GetQuotes();

                return Ok(new ApiResponse
                {
                    responseCode = "00",
                    responseMessage = "Success",
                    data = tags
                });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse
                {
                    responseCode = "99",
                    responseMessage = ex.Message,
                    data = new List<Tag>()
                });
            }
        }

        public async Task<IActionResult> GetAllTags()
        {
            try
            {
                var tags = await _tagService.GetAllTags();

                return Ok(new ApiResponse
                {
                    responseCode = "00",
                    responseMessage = "Success",
                    data = tags
                });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse
                {
                    responseCode = "99",
                    responseMessage = ex.Message,
                    data = new List<Tag>()
                });
            }
        }

        public async Task<IActionResult> GetQuote(int id)
        {
            try
            {
                var quote = await _quotesService.GetQuote(id);

                if (quote is null)
                {
                    return NotFound(new ApiResponse
                    {
                        responseCode = "01",
                        responseMessage = "Object not found",
                        data = id
                    });
                }

                return Ok(new ApiResponse
                {
                    responseCode = "00",
                    responseMessage = "Success",
                    data = quote
                });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse
                {
                    responseCode = "99",
                    responseMessage = ex.Message,
                    data = id
                });
            }
        }

        public async Task<IActionResult> GetRandomQuote()
        {
            try
            {
                var quote = await _quotesService.GetQuotes();

                if (quote is null || !quote.Any())
                {
                    return NotFound(new ApiResponse
                    {
                        responseCode = "01",
                        responseMessage = "No data",
                    });
                }

                //var quoteToPickFrom = quote.Take(5);

                var randInt = Random.Shared.Next(0, quote.Count());

                var randomQuote = quote.ToList().ElementAt(randInt);

                return Ok(new ApiResponse
                {
                    responseCode = "00",
                    responseMessage = "Success",
                    data = randomQuote!
                });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ApiResponse
                {
                    responseCode = "99",
                    responseMessage = ex.Message,
                });
            }
        }
    }
}
