using Library_Management.API.Data;
using Library_Management.API.Models;

namespace Library_Management.API.Mapping
{
    public static class NewBookRequestToModel
    {
        public static Book ToModel(this NewBookRequest request) 
        {
             return new Book(request.Title, request.Author, request.ISBN, request.YearOfPublication);
        }
    }
}
