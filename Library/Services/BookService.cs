using Library.Entities;
using Library.Interfaces;
using Library.Models;
using Library.Persistence.Repositorys;
using Library.Repositorys;

namespace Library.Services;

public class BookService : IBookService
{
    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }
    private readonly IBookRepository _repository;
    
    public async Task<ResultViewModel<List<BookViewModel>>> GetAllBooks()
    {
        var books = await _repository.GetAllAsync();
        var model = books.Select(BookViewModel.FromEntity).ToList();
        return ResultViewModel<List<BookViewModel>>.Success(model);
    }

    public async Task<ResultViewModel<BookViewModel>> GetBook(int id)
    {
        var book = await _repository.GetByIdAsync(id);
        var model = BookViewModel.FromEntity(book);
        return ResultViewModel<BookViewModel>.Success(model);
    }

    public async Task<ResultViewModel> AddBook(BookInputModel input)
    {
        var book = input.ToEntity();
        await _repository.AddAsync(book);
        return ResultViewModel.Success();
    }

    public async Task<ResultViewModel> DeleteBook(int id)
    {
        var book = await _repository.GetByIdAsync(id);
        book.SetIsDeleted();
        await _repository.UpdateAsync(book);
        return ResultViewModel.Success();
    }
}