using AutoMapper;
using MetalWorm.NoteApp.BL.Abstract;
using MetalWorm.NoteApp.Dal.Mapper;
using MetalWorm.NoteApp.Dal.Repositories.Abstract;
using MetalWorm.NoteApp.Dal.Repositories.Concrete;
using MetalWorm.NoteApp.Dto;
using MetalWorm.NoteApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalWorm.NoteApp.BL.Concrete
{
    public class NoteManager : GenericManager<Note>, INoteManager
    {
        private readonly INoteRepository _noteRepo;
        private readonly IMapper _mapper;

        public NoteManager()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoMapper>(); // DtoMapper sınıfını ekleyin
            });

            _noteRepo = new NoteRepository();
            _mapper = config.CreateMapper();
        }
        public async Task<IEnumerable<NoteViewDto>> GetUserNotes(User user)
        {
            List<NoteViewDto> noteDtos = new List<NoteViewDto>();
            
            IEnumerable<Note> notes = await _noteRepo.GetNotesAsync(user);
            foreach (Note note in notes)
            {
                NoteViewDto noteDto = _mapper.Map<NoteViewDto>(note);
                noteDtos.Add(noteDto);
            }
            return noteDtos;
        }
    }
}
