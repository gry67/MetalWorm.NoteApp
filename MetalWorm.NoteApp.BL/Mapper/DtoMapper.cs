using AutoMapper;
using MetalWorm.NoteApp.Dto;
using MetalWorm.NoteApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalWorm.NoteApp.Dal.Mapper
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<Note, NoteViewDto>().ReverseMap();
            CreateMap<Note,NoteUpdateDto>().ReverseMap();
            CreateMap<User, UserViewDto>().ReverseMap();
        }
    }
}
