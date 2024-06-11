using AutoMapper;
using KanbanASP.BLL.DTO;
using KanbanASP.BLL.Interfaces;
using KanbanASP.BLL.Infrastructure;
using KanbanASP.DAL.Interfaces;
using KanbanASP.DAL.Entities;
using KanbanASP.DAL.Repositories;

namespace KanbanASP.BLL.Services
{
    public class ProjectService : IService<ProjectDTO>
    {
        //IUnitOfWork db { get; set; }

        private EFUnitOfWork db { get; set; }

        public ProjectService(/*IUnitOfWork uow*/)
        {
            this.db = new EFUnitOfWork();
        }

        public IEnumerable<ProjectDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Project, ProjectDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Project>, List<ProjectDTO>>(db.Projects.GetAll());
        }

        public ProjectDTO Get(int id)
        {
            //if (id == null)
            //    throw new ValidationException("Не найден id", "");

            var proj = db.Projects.Get(id);

            if (proj == null)
                throw new ValidationException("Проект не найден", "");

            return new ProjectDTO
            {
                Id = proj.Id,
                Name = proj.Name,
                Status = proj.Status
            };
        }

        public void Create(ProjectDTO item)
        {
            var mapper = new MapperConfiguration(conf => conf.CreateMap<ProjectDTO, Project>()).CreateMapper();
            var newitem = mapper.Map<Project>(item);

            db.Projects.Create(newitem);
            db.Save();
        }

        public void Update(ProjectDTO item)
        {
            var mapper = new MapperConfiguration(conf => conf.CreateMap<ProjectDTO, Project>()).CreateMapper();
            var newitem = mapper.Map<Project>(item);

            db.Projects.Update(newitem);
            db.Save();
        }

        public void Delete(int id)
        {
            //if (id == null)
            //    throw new ValidationException("Не найден id", "");
            
            db.Projects.Delete(id);
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
