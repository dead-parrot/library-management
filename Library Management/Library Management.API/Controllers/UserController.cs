using Library_Management.API.Data;
using Library_Management.API.Mapping;
using Library_Management.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly LibDbContext _db;
        public UserController(LibDbContext db) 
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult CreateUser(NewUserRequest request) 
        {
            var user = request.ToModel();
            _db.Users.Add(user);
            _db.SaveChanges();
            return Ok(user);
        }
    }
}
