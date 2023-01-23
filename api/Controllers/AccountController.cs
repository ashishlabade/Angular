using System.Security.Cryptography;
using System.Text;
using api.Data;
using api.DTOs;
using api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace api.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        public AccountController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("register")] // api/account/register
        public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
        {
            if(await UserExists(registerDto.Username)) return BadRequest("The user: "+registerDto.Username+" already exists");

            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key

            };
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        private async Task<bool> UserExists(string username)
        {
            return await _context.users.AnyAsync(x => x.UserName == username.ToLower());
        }
        
    }
}