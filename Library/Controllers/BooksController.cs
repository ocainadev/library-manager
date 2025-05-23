using Library.Entities;
using Library.Interfaces;
using Library.Models;
using Library.Persistence.Repositorys;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    public BooksController(IBookService bookService)
        => _service = bookService;
    
    private readonly IBookService _service;
    
    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var result = await _service.GetAllBooks();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBook(int id)
    {
        var result = await _service.GetBook(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddBook(BookInputModel input)
    {
        var result = await _service.AddBook(input);
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var result = await _service.DeleteBook(id);
        return Ok(result);
    }
}