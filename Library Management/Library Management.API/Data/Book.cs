namespace Library_Management.API.Data;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int YearOfPublication { get; set; }

    public Book(string title, string author, string iSBN, int yearOfPublication)
    {
        Id = Guid.NewGuid();
        Title = title;
        Author = author;
        ISBN = iSBN;
        YearOfPublication = yearOfPublication;
    }
}