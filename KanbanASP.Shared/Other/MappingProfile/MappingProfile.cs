using AutoMapper;
using KanbanASP.Shared.Entities;
using KanbanASP.Shared.DTO;


namespace KanbanASP.Shared.Other.MappingProfile
{
   public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           // CreateMap<Project, ProjectDTO>();
            CreateMap<User, UserDTO>();
        }
    }
}
