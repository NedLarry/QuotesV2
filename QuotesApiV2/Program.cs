using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using QuotesApiV2.Domain;
using QuotesApiV2.Middleware;
using QuotesApiV2.Services;
using QuotesApiV2.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Qoutes v2", Description = "Quotes Service", Version = "v1" });
    c.AddSecurityDefinition("ApiKey", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "ApiKey must appear in header",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Name = "XApiKey",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header
    });

    c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Name = "XApiKey",
                Type = SecuritySchemeType.ApiKey,
                In = ParameterLocation.Header,
                Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "ApiKey"}
            },
            new List<string>()
        }
    });
});

builder.Services.AddDbContext<QuotesContext>(opt =>
opt.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddTransient<IServiceAgregator, ServiceAggregator>();
builder.Services.AddTransient<IQuotesService, QuotesService>();
builder.Services.AddTransient<ITagService, TagService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ApiKeyMiddleware>();

app.UseSeeding();

app.UseAuthorization();

app.MapControllers();

app.Run();
