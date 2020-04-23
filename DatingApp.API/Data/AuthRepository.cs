using System;
using System.Threading.Tasks;
using DatingApp.API.Controllers.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> login(string username, string password)
        {
            var user = await _context.users.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
                return null;

            if (!verifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            await _context.SaveChangesAsync();
            return user;
        }

        private bool verifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using ( var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt) ) 
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++) {
                    if (computedHash[i] != passwordHash[i]) //if passwords ever don't match
                        return false;
                }
            }
            return true;
        }

        public async Task<User> register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
            
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using ( var hmac = new System.Security.Cryptography.HMACSHA512() ) 
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> userExists(string username)
        {
            if (await _context.users.AnyAsync(x => x.Username == username))
                return true;
                
            return false;
        }
    }
}