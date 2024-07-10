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
        }

        public void Delete(int id)
        {
            MyTask? task = db.Tasks.Find(id);

            if (task != null)
            {
                db.Tasks.Remove(task);
            }            
        }

        public IEnumerable<MyTask> Find(Func<MyTask, bool> predicate)
        {
            return db.Tasks.Where(predicate).ToList();
        }

        public MyTask? Get(int id)
        {
            return db.Tasks.Find(id);
        }

        public IEnumerable<MyTask> GetAll()
        {
            return db.Tasks;
        }

        public void Update(MyTask item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
