using api.Data;
using api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Asynchronous Code
namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // GET /api/users

    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context) // Constructor
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers() // Show all users /api/users
        {
            var users = await _context.users.ToListAsync();
            return users;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id) // Show user with id /api/users/id
        {
            return await _context.users.FindAsync(id);
        }
    }
}