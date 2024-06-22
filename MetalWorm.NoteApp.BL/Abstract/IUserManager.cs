using MetalWorm.NoteApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalWorm.NoteApp.BL.Abstract
{
    public interface IUserManager : IGenericManager<User>
    {
        Task<User> CheckUserAsync(string userName,string password);
    }
}
