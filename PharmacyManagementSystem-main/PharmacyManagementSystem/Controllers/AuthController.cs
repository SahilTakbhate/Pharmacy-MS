using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PharmacyManagementSystem.Authentication;
using PharmacyManagementSystem.Data;
using PharmacyManagementSystem.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace PharmacyManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly PharmacyManagementSystemContext _context;
        private readonly IConfiguration _configuration;
        public AuthController(PharmacyManagementSystemContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }





        public static User user = new User();

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterUser request)
        {

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);


            user.Name = request.Name;
            user.Email = request.Email;
            user.Contact = request.Contact;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            if (_context.User == null)
            {
                return Problem("Entity set 'PharmacyManagementSystemContext.User'  is null.");
            }
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(LoginUser request)
        {
            if (user.Email != request.Email)
            {
                return BadRequest("User not found.");

            }

            if (!VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return BadRequest("Invalid credentials.");

            }

            string token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Name)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Key").Value));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }


    }
}
