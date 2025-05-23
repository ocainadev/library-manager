namespace Library.Entities;

public class Book
{
    public Book(string title, string author, string isbn, int yearOfPublication)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        YearOfPublication = yearOfPublication;
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public int YearOfPublication { get; set; }
    public bool IsDeleted { get; set; } = false;
    
    public void SetIsDeleted()
    {
        IsDeleted = true;
    }
}