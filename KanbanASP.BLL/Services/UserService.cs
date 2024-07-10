using AutoMapper;
using KanbanASP.BLL.DTO;
using KanbanASP.BLL.Interfaces;
using KanbanASP.BLL.Infrastructure;
using KanbanASP.DAL.Interfaces;
using KanbanASP.DAL.Entities;
using KanbanASP.DAL.Repositories;

namespace KanbanASP.BLL.Services
{
    public class UserService : IService<UserDTO>
    {
        //IUnitOfWork db { get; set; }

        private EFUnitOfWork db { get; set; }

        public UserService(/*IUnitOfWork uow*/)
        {
            //this.db = uow;
            db = new EFUnitOfWork();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<User>, List<UserDTO>>(db.Users.GetAll());
        }

        public UserDTO Get(int id)
        {
            //if (id == null)
            //    throw new ValidationException("Не найден id", "");

            var user = db.Users.Get(id);

            if (user == null)
                throw new ValidationException("Пользователь не найден", "");

            return new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                SecondName = user.SecondName,
                LastName = user.LastName,
                Position = user.Position,
                Password = user.Password,
                AdminRights = user.AdminRights,
                BossRights = user.BossRights
            };
        }

        public void Create(UserDTO item)
        {
            var mapper = new MapperConfiguration(conf => conf.CreateMap<UserDTO, User>()).CreateMapper();
            var newitem = mapper.Map<User>(item);

            db.Users.Create(newitem);
            db.Save();
        }

        public void Update(UserDTO item)
        {
            var mapper = new MapperConfiguration(conf => conf.CreateMap<UserDTO, User>()).CreateMapper();
            var newitem = mapper.Map<User>(item);

            db.Users.Update(newitem);
            db.Save();
        }

        public void Delete(int id)
        {
            //if (id == null)
            //    throw new ValidationException("Не найден id", "");
            
            db.Users.Delete(id);
            db.Save();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
