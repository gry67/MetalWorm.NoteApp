using MetalWorm.NoteApp.Dal.Repositories.Abstract;
using MetalWorm.NoteApp.Dal.Repositories.Concrete;
using MetalWorm.NoteApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalWorm.NoteApp.Dal.UnitOfWork
{
    public class UOW : IUOW
    {
        private readonly AppDbContext _appDbContext;
        public UOW()
        {
            _appDbContext = new AppDbContext();
        }
        public UserRepository UserRepository { get; }
        public NoteRepository NoteRepository { get; }

        public async Task SaveAsync()
        {
            _appDbContext.SaveChangesAsync();
        }
    }
}
