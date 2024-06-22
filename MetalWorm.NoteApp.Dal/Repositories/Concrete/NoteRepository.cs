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
    public class NoteRepository : GenericRepository<Note>, INoteRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<Note> _notes;

        public NoteRepository()
        {
            _appDbContext = new AppDbContext();
            _notes = _appDbContext.Set<Note>();
        }
        public async Task<IEnumerable<Note>> GetNotesAsync(User user)
        {
            return await _notes.Where(x=>x.UserId == user.Id).ToListAsync();
        }
    }
}
