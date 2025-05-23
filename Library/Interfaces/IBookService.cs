using Library.Models;

namespace Library.Interfaces;

public interface IBookService
{
    Task<ResultViewModel<List<BookViewModel>>> GetAllBooks();
    Task<ResultViewModel<BookViewModel>> GetBook(int id);
    Task<ResultViewModel> AddBook(BookInputModel input);
    Task<ResultViewModel> DeleteBook(int id);
}