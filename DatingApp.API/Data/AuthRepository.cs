using System;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class AuthRepository : IAuthRepository
    {
        public DataContext _Context { get; }

        public AuthRepository(DataContext Context)
        {
           _Context = Context;


        }
        public async Task<User> LogIn(string username, string password)
        {
          var user=  await _Context.Users.FirstOrDefaultAsync(x => x.UserName == username); 
          if (user == null)
           return null;
          if(!VerifyPassword(password, user.PasswordHash,user.PasswordSalt))
            return null; 
          return user;
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for(int i=0 ;i<passwordHash.Length;i++)
                {
                    if(computedHash[i] !=passwordHash[i])
                     return false;
                }
                return true;
            }
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePassWordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            await _Context.Users.AddAsync(user); 
            await _Context.SaveChangesAsync(); 
            return user;

        }

        private void CreatePassWordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExist(string username)
        {
            var userExist= await _Context.Users.FirstOrDefaultAsync(x => x.UserName == username) ;
            if( userExist != null)
              return true; 
            return false; 
        }
    }
}