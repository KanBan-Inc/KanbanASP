using KanbanASP.DAL.EF;
using KanbanASP.DAL.Interfaces;
using KanbanASP.DAL.Entities;

namespace KanbanASP.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private Context db;
        private UserRepository userRepository;
        private ProjectRepository projectRepository;
        private MyTaskRepository myTaskRepository;

        public EFUnitOfWork()
        {
            db = new Context();
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(db);
                }
                return userRepository;
            }
        }

        public IRepository<Project> Projects
        {
            get
            {
                if(projectRepository == null)
                {
                    projectRepository = new ProjectRepository(db);
                }
                return projectRepository;
            }
        }

        public IRepository<MyTask> Tasks
        {
            get
            {
                if (myTaskRepository == null)
                {
                    myTaskRepository = new MyTaskRepository(db);
                }
                return myTaskRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
