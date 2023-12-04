using ApplicationCore.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data_Access
{
    public class Repository<T> : IRepository<T> where T : class
    {
        //The following variable is going to hold the HomePadContext instance
        private HomePadContext _context = null;
        //The following Variable is going to hold the DbSet Entity
        private DbSet<T> set = null;
        //Using the Parameterless Constructor, 
        //we are initializing the context object and table variable
        public Repository()
        {
            this._context = new HomePadContext();
            //Whatever class name we specify while creating the instance of Repository
            //That class name will be stored in the set variable
            set = _context.Set<T>();
        }
        //Using the Parameterized Constructor, 
        //we are initializing the context object and set variable
        public Repository(HomePadContext _context)
        {
            this._context = _context;
            set = _context.Set<T>();
        }


        public IEnumerable<T> GetAll()
        {
            return set.ToList();
        }

        public T GetById(int i)
        {
            return set.Find(i);
        }

        public void Insert(T obj)
        {
            set.Add(obj);
        }

        public void Update(T obj)
        {
            //First attach the object to the set
            set.Attach(obj);
            //Then set the state of the Entity as Modified
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Delete(object i)
        {
            //First, fetch the record from the set
            T existing = set.Find(i);
            //This will mark the Entity State as Deleted
            set.Remove(existing);
        }

    }
}
