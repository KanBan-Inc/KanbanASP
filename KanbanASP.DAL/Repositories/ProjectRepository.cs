using System;
using System.Collections.Generic;
using System.Linq;
using KanbanASP.DAL.Entities;
using KanbanASP.DAL.EF;
using KanbanASP.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KanbanASP.DAL.Repositories
{
    public class ProjectRepository : IRepository<Project>
    {
        private Context db;

        public ProjectRepository(Context db)
        {
            this.db = db;
        }

        public void Create(Project item)
        {
            db.Projects.Add(item);
        }

        public void Delete(int id)
        {
            Project? proj = db.Projects.Find(id);

            if (proj != null)
            {
                db.Projects.Remove(proj);
            }
        }

        public IEnumerable<Project> Find(Func<Project, bool> predicate)
        {
            return db.Projects.Where(predicate).ToList();
        }

        public Project? Get(int id)
        {
            return db.Projects.Find(id);
        }

        public IEnumerable<Project> GetAll()
        {
            return db.Projects;
        }

        public void Update(Project item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
