using Microsoft.EntityFrameworkCore;
using QuotesApiV2.Domain;
using QuotesApiV2.Middleware;
using QuotesApiV2.Services;
using QuotesApiV2.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

//app.UseMiddleware<ApiKeyMiddleware>();


app.UseAuthorization();

app.MapControllers();

app.Run();
