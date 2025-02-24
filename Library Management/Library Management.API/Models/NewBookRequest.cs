namespace Library_Management.API.Models;

public class NewBookRequest
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int YearOfPublication { get; set; }
}
