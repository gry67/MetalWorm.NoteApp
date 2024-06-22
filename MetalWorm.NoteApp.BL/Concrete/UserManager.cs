using MetalWorm.NoteApp.BL.Abstract;
using MetalWorm.NoteApp.Dal.Repositories.Abstract;
using MetalWorm.NoteApp.Dal.Repositories.Concrete;
using MetalWorm.NoteApp.Dal.UnitOfWork;
using MetalWorm.NoteApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MetalWorm.NoteApp.BL.Concrete
{
    public class UserManager : GenericManager<User>, IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IUOW _unitOf_Work;

        public UserManager()
        {
            _userRepository = new UserRepository();
            _unitOf_Work = new UOW();
        }
        public Task<User> CheckUserAsync(string userName, string password)
        {
            var user = _unitOf_Work.UserRepository.CheckUser(userName, password);
            _unitOf_Work.SaveAsync();
            return user;
            //return _userRepository.CheckUser(userName, password);
        }
    }
}
