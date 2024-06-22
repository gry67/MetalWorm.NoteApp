using MetalWorm.NoteApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalWorm.NoteApp.Dal.Repositories.Abstract
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> CheckUser(string userName,string password);
    }
}
