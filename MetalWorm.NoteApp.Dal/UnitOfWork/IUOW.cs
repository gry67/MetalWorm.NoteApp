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
        public interface IUOW
        {
            UserRepository UserRepository { get; }
            Task SaveAsync();
        }
    }
