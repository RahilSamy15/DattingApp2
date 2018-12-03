using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DatingRepository : IDattingRepository
    {
        public DataContext _context { get; }
        public DatingRepository(DataContext _context)
        {
            this._context = _context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity); 
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync( x => x.Id == id );
            return user;
        }

        public async Task<IEnumerable<User>> getUsers()
        {
            var users = await _context.Users.Include(p => p.Photos).ToListAsync(); 
            return users; 
        }

        public void Delete<T>(T entity) where T : class
        {
           _context.Remove(entity); 
        }

        public async Task<bool> saveAll()
        {
            return  await _context.SaveChangesAsync() > 0;
                }
    }
}