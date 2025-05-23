using Library.Entities;

namespace Library.Persistence.Repositorys;

public interface IBookRepository
{
    Task<List<Book>> GetAllAsync();
    Task<Book> GetByIdAsync(int id);
    Task<Book> AddAsync(Book book);
    Task<Book> UpdateAsync(Book book);
    Task<bool> ExistByIdAsync(int id);
}