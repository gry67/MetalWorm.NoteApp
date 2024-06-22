using MetalWorm.NoteApp.Dto;
using MetalWorm.NoteApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalWorm.NoteApp.BL.Abstract
{
    public interface INoteManager : IGenericManager<Note>
    {
        Task<IEnumerable<NoteViewDto>> GetUserNotes(User user);
    }
}
