using Library.Entities;

namespace Library.Models;

public class BookViewModel
{
    public BookViewModel(string title, string author, string isbn, int yearOfPublication)
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

    public static BookViewModel FromEntity(Book input)
        => new (input.Title, input.Author, input.Isbn, input.YearOfPublication);
}