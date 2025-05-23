using Library.Entities;

namespace Library.Models;

public class BookInputModel
{
    public BookInputModel(string title, string author, string isbn, int yearOfPublication)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        YearOfPublication = yearOfPublication;
    }
    
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public int YearOfPublication { get; set; }

     public Book ToEntity()
    => new (Title, Author, Isbn, YearOfPublication);
}
