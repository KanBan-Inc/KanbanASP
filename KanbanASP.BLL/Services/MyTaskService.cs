using AutoMapper;
using KanbanASP.BLL.DTO;
using KanbanASP.BLL.Interfaces;
using KanbanASP.BLL.Infrastructure;
using KanbanASP.DAL.Interfaces;
using KanbanASP.DAL.Entities;
using KanbanASP.DAL.Repositories;

namespace KanbanASP.BLL.Services
{
    public class MyTaskService : IService<MyTaskDTO>
    {
        //IUnitOfWork db { get; set; }

        private EFUnitOfWork db { get; set; }

        public MyTaskService(/*IUnitOfWork uow*/)
        {
            this.db = new EFUnitOfWork();
        }

        public IEnumerable<MyTaskDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<MyTask, MyTaskDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<MyTask>, List<MyTaskDTO>>(db.Tasks.GetAll());
        }

        public MyTaskDTO Get(int id)
        {
            //if (id == null)
            //    throw new ValidationException("Не найден id", "");

            var task = db.Tasks.Get(id);

            if (task == null)
                throw new ValidationException("Задача не найдена", "");

            return new MyTaskDTO
            {
                Id = task.Id,
                Name = task.Name,
                Status = task.Status,
                Priority = task.Priority,
                Deadline = task.Deadline,
                ProjectId = task.ProjectId,
                UserId = task.UserId
            };
        }

        public void Create(MyTaskDTO item)
        {
            var mapper = new MapperConfiguration(conf => conf.CreateMap<MyTaskDTO, MyTask>()).CreateMapper();
            var newitem = mapper.Map<MyTask>(item);

            db.Tasks.Create(newitem);
            db.Save();
        }

        public void Update(MyTaskDTO item)
        {
            var mapper = new MapperConfiguration(conf => conf.CreateMap<MyTaskDTO, MyTask>()).CreateMapper();
            var newitem = mapper.Map<MyTask>(item);

            db.Tasks.Update(newitem);
            db.Save();
        }

        public void Delete(int id)
        {
            //if (id == null)
            //    throw new ValidationException("Не найден id", "");
            
            db.Tasks.Delete(id);
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
