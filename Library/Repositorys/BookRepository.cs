using Library.Entities;
using Library.Persistence;
using Library.Persistence.Repositorys;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositorys;

public class BookRepository : IBookRepository
{
    public BookRepository(LibraryDbContext context)
    {
        _context = context;
    }
    private readonly LibraryDbContext _context;
    
    
    public async Task<List<Book>> GetAllAsync()
    {
         return await _context.Books.AsNoTracking().Where(b => b.IsDeleted == false).ToListAsync();
    }

    public async Task<Book> GetByIdAsync(int id)
    {
        return (await _context.Books.FirstOrDefaultAsync(b => b.Id == id))!;
    }

    public async Task<Book> AddAsync(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<Book> UpdateAsync(Book book)
    {
        _context.Update(book);
        await _context.SaveChangesAsync();
        return book;
    }

    public async Task<bool> ExistByIdAsync(int id)
    {
        return await _context.Books.AnyAsync(b => b.Id == id);
        
    }
}