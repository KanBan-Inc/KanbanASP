using KanbanASP.DAL.Interfaces;
using KanbanASP.DAL.Entities;
using KanbanASP.DAL.EF;

namespace KanbanASP.DAL.Repositories
{
    public class ProjectRepository : IRepository<Project>
    {
        private readonly Context _context;

        ProjectRepository(Context context)
        {
            _context = context;
        }

        public void Create(Project item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> Find(Func<Project, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Project Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetAll()
        {
            return _context.Projects;
        }

        public void Update(Project item)
        {
            throw new NotImplementedException();
        }
    }
}
