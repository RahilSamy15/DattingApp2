using System;
using System.Collections.Generic;
using DatingApp.API.Models;
using Newtonsoft.Json;

namespace DatingApp.API.Data
{
    public class Seed
    {
        public DataContext _DateContext { get; }
        public Seed(DataContext _DateContext)
        {
            this._DateContext = _DateContext;

        }
        public void SeedUsers()
        {
            var UserData = System.IO.File.ReadAllText("Data/UserSeedData.Json"); 
            var Users = JsonConvert.DeserializeObject<List<User>>(UserData); 
            foreach (var user in Users)
            {
                byte[] passwordHash, passwordSalt ;
                CreateHashPwd("password", out passwordHash , out passwordSalt); 
                user.PasswordHash= passwordHash; 
                user.PasswordSalt = passwordSalt; 
                user.UserName = user.UserName.ToLower(); 
                _DateContext.Users.Add(user);
            }
            _DateContext.SaveChanges();
        }

        private void CreateHashPwd(string v, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac =   new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; 
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(v));
            }
        }
    }
}