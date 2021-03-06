using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IDattingRepository
    {
         void Add <T> (T entity) where T : class; 
         void Delete<T> (T entity) where T :class;
          
          Task<bool> saveAll();
          Task<IEnumerable<User>> getUsers();

          Task<User> GetUser(int Id); 
    }
}