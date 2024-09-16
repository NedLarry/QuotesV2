using Microsoft.EntityFrameworkCore;
using QuotesApiV2.Domain;
using QuotesApiV2.Domain.Models;

namespace QuotesApiV2.Middleware
{
    public static class DbInitializer
    {
        public static async void UseSeeding(this IApplicationBuilder app)
        {
            using var scopedService = app.ApplicationServices.CreateScope();

            var context = scopedService.ServiceProvider.GetService<QuotesContext>();

            if (context!.Database.GetMigrations().Any())
            {
                if ((await context.Database.GetPendingMigrationsAsync()).Any())
                {
                    await context.Database.MigrateAsync();
                }


                if (!context.Quotes.Any())
                {
                    var quoteList = new List<Quote>
                    {
                        new Quote
                        {
                            Author = "Admin et al",
                            Content = "For the wise man, to imagine is to see;\n For the magician, to speak is to create.",
                            Tags = string.Join(' ', "Esoteric", "Spiritual")
                        },

                        new Quote
                        {
                            Author = "Admin et al",
                            Content = "There is no invisible world, there are however, many degrees of perfection of being",
                            Tags = string.Join(' ', "Esoteric", "Spiritual")
                        },

                        new Quote
                        {
                            Author = "Admin",
                            Content = "Loneliness is a kind of tax you have to pay to atone for a certain complexity of mind.",
                            Tags = string.Join(' ', "Esoteric", "Philosophy")
                        },

                        new Quote
                        {
                            Author = "Admin et al",
                            Content = "Each act and each thought has a cause, and the cause of the cause is the law.",
                            Tags = string.Join(' ', "Esoteric", " Spiritual")
                        },

                        new Quote
                        {
                            Author = "Admin et al",
                            Content = "To expel the darkness of this chaos,\n and force it to give\n" +
                            "perfect forms to our thoughts.\n This is to be a man of Genius,\n" +
                            "it is to create, it is to be victorious over hell.",
                            Tags = string.Join(' ', "Esoteric", "Spiritual")
                        },

                        new Quote
                        {
                            Author = "Admin",
                            Content = "The will only assurs itself by acts.",
                            Tags = string.Join(' ', "Esoteric", "Spiritual")
                        }
                    };


                    await context.Quotes.AddRangeAsync(quoteList);

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
