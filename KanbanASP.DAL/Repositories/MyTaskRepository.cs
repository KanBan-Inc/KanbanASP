using System;
using System.Collections.Generic;
using System.Linq;
using KanbanASP.DAL.Entities;
using KanbanASP.DAL.EF;
using KanbanASP.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KanbanASP.DAL.Repositories
{
    public class MyTaskRepository : IRepository<MyTask>
    {
        private Context db;

        public MyTaskRepository(Context db)
        {
            this.db = db;
        }

        public void Create(MyTask item)
        {
            db.Tasks.Add(item);
            db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            MyTask? task = db.Tasks.First(x => x.Id == id);

            if (task != null)
            {
                db.Tasks.Remove(task);
                db.SaveChanges();
            }            
        }

        public IEnumerable<MyTask> Find(Func<MyTask, bool> predicate)
        {
            List<MyTask> tasks = db.Tasks.Where(predicate).ToList();

            return tasks;
        }

        public MyTask? Get(Guid? id)
        {
            return db.Tasks.First(x => x.Id == id);
        }

        public IEnumerable<MyTask> GetAll()
        {
            List<MyTask> tasks = db.Tasks.ToList();

            return tasks;
        }

        public void Update(MyTask item)
        {
            db.Tasks.Update(item);
            db.SaveChanges();
        }
    }
}
