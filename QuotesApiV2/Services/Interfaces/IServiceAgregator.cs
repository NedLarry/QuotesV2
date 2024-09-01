﻿using Microsoft.AspNetCore.Mvc;
using QuotesApiV2.Domain.Dtos;

namespace QuotesApiV2.Services.Interfaces
{
    public interface IServiceAgregator
    {
        Task<IActionResult> CreateQuote(CreateQuoteDto request);

        Task<IActionResult> CreateTag(CreateTagDto request);
    }
}