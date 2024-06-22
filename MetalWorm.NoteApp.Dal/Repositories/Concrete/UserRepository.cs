using MetalWorm.NoteApp.Dal.Repositories.Abstract;
using MetalWorm.NoteApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalWorm.NoteApp.Dal.Repositories.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<User> _users;

        public UserRepository()
        {
            _appDbContext = new AppDbContext();
            _users = _appDbContext.Set<User>();
        }
        public async Task<User> CheckUser(string userName, string password)
        {
            var user = await _users.FirstOrDefaultAsync(x=>x.UserName == userName && x.Password==password);
            if (user==null)
            {
                return null;
            }
            else
            {
                return user;
            }
        }
    }
}
