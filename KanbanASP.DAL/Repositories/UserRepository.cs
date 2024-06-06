using System;
using System.Collections.Generic;
using System.Linq;
using KanbanASP.DAL.Entities;
using KanbanASP.DAL.EF;
using KanbanASP.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KanbanASP.DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private Context db;

        public UserRepository(Context db)
        {
            this.db = db;
        }

        public void Create(User item)
        {
            db.Users.Add(item);
            db.SaveChanges();
            //throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            User? user = db.Users.First(x => x.Id == id);

            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }            
            //throw new NotImplementedException();
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            List<User> users = db.Users.Where(predicate).ToList();

            return users;
            //throw new NotImplementedException();
        }

        public User? Get(Guid? id)
        {
            return db.Users.First(x => x.Id == id);
            //throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users = db.Users.ToList();

            return users;
            //throw new NotImplementedException();
        }

        public void Update(User item)
        {
            db.Users.Update(item);
            db.SaveChanges();
            //throw new NotImplementedException();
        }
    }
}
