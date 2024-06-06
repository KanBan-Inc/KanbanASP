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
            db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            Project? proj = db.Projects.First(x => x.Id == id);

            if (proj != null)
            {
                db.Projects.Remove(proj);
                db.SaveChanges();
            }            
        }

        public IEnumerable<Project> Find(Func<Project, bool> predicate)
        {
            List<Project> projects = db.Projects.Where(predicate).ToList();

            return projects;
        }

        public Project? Get(Guid? id)
        {
            return db.Projects.First(x => x.Id == id);
        }

        public IEnumerable<Project> GetAll()
        {
            List<Project> projects = db.Projects.ToList();

            return projects;
        }

        public void Update(Project item)
        {
            db.Projects.Update(item);
            db.SaveChanges();
        }
    }
}
