using System;
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.Base
{
    public abstract class BaseInMemoryRepository<T>:
        IBaseRepository<T>
        where T : BaseModel<T>      // Au moins un BaseModel
    {
        protected List<T> _context;
        public virtual IQueryable<T> Context
        {
            get
            {
                if (_context != null) return _context.AsQueryable();
                _context= SampleData;
                return _context.AsQueryable();
            }
        }

        public abstract List<T> SampleData { get; }

        public int NewId() =>
            Context.Max(c => c.Id) + 1;

        public T Single(int id) =>
            Context.SingleOrDefault(c => c.Id == id); 
            //Renvoie null si il y en a pas, lève un expression si il y en a plusieurs
    
        public T Single(string name) =>
            Context.FirstOrDefault(c => c.Name.Equals(name)); 
            //Renvoie null si il y en a pas, renvoie le Premier si il y en a plusieurs

        public void Delete(int id)
        {
            var entityToDelete = Single(id);
            if(entityToDelete == null) return ;
            ContextTemp.Remove(entityToDelete);
        }

        public void Delete(T entity) =>
            Delete(entity.Id);

        public IEnumerable<T> GetAll() => 
            Context;

        public IEnumerable<T> Find(
            Func<T, bool> predicate) =>
            Context.Where(predicate);

        public void Update(T entity)
        {
            if (entity == null) return;

            var copy = ContextTemp;

            if (entity.isNew())
            {
                entity.Id = NewId();
                ContextTemp.Add(entity);
            }
            else
            {
                var existing = Single(entity.Id);
                existing.Map(entity);
            }
        }

        protected List<T> _contextTemp;
        protected List<T> ContextTemp =>
            _contextTemp ?? 
                    (_contextTemp = Context.ToList());

        public void SaveChanges()
        {
            _context = _contextTemp;
            _contextTemp = null;
        }
    }
}