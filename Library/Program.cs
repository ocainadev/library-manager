using Library.Interfaces;
using Library.Persistence;
using Library.Persistence.Repositorys;
using Library.Repositorys;
using Library.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DBContext
builder.Services.AddDbContext<LibraryDbContext>(c => c.UseSqlite("Data Source=Library.db"));

// Services
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment()) 
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
