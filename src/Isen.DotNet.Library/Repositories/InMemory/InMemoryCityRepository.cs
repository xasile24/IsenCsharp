using System;
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models;

namespace Isen.DotNet.Library.Repositories.inMemoryCityRepository
{
    public class inMemoryCityRepository
    {
        private List<City> _context;
        public IQueryable<City> Context
        {
            get
            {
                if (_context != null) return _context.AsQueryable();
                _context= new List<City>()
                {
                    new City() {Id = 1, Name = "Toulon", ZipCode = "83000"},
                    new City() {Id = 2, Name = "Marseille", ZipCode = "13000"},
                    new City() {Id = 3, Name = "Nice", ZipCode = "06000"},
                    new City() {Id = 4, Name = "Paris", ZipCode = "75000"},
                    new City() {Id = 5, Name = "Lyon", ZipCode = "69000"}
                };
                return _context.AsQueryable();
            }
        }
    
        public int NewId() =>
            Context.Max(c => c.Id) + 1;

        public City Single(int id) =>
            Context.SingleOrDefault(c => c.Id == id); 
            //Renvoie null si il y en a pas, lève un expression si il y en a plusieurs
    
        public City Single(string name) =>
            Context.FirstOrDefault(c => c.Name.Equals(name)); 
            //Renvoie null si il y en a pas, renvoie le Premier si il y en a plusieurs

        public void Update(City entity)
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
                existing.Name = entity.Name;
                existing.ZipCode = entity.ZipCode;
            }
        }

        public void Delete(int id)
        {
            var entityToDelete = Single(id);
            if(entityToDelete == null) return ;
            ContextTemp.Remove(entityToDelete);
        }

        public void Delete(City entity) =>
            Delete(entity.Id);

        private List<City> _contextTemp;
        private List<City> ContextTemp =>
            _contextTemp ?? 
                    (_contextTemp = Context.ToList());

        public void SaveChanges()
        {
            _context = _contextTemp;
            _contextTemp = null;
        }
    }
}