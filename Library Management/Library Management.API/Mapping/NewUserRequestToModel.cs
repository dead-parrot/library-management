using Library_Management.API.Data;
using Library_Management.API.Models;

namespace Library_Management.API.Mapping;

public static class NewUserRequestToModel
{
    public static User ToModel(this NewUserRequest request)
    {
        return new User(request.Nome, request.Email);
    }
}
