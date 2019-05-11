using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;

namespace Isen.DotNet.Library.Context
{
    public class SeedData
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICityRepository _cityRepository;
        private readonly IPersonRepository _personRepository;

        public SeedData(
            ApplicationDbContext dbContext,
            ICityRepository cityRepository,
            IPersonRepository personRepository)
        {
            _dbContext = dbContext;
            _cityRepository = cityRepository;
            _personRepository = personRepository;
        }

        public void DropCreateDatabase()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }

        public void AddCities()
        {
            // Ne rien faire s'il y a déjà des villes
            if (_dbContext.CityCollection.Any()) return;

            var cities = new List<City>
            {
                new City { Name = "Toulon", ZipCode = "83000" },
                new City { Name = "Marseille", ZipCode = "13000" },
                new City { Name = "Nice", ZipCode = "06000" },
                new City { Name = "Lyon", ZipCode = "69000" }
            };
            cities.ForEach(city => _cityRepository.Update(city));
            _cityRepository.SaveChanges();
        }

        public void AddPersons()
        {
            // Ne rien faire si non vide
            if(_dbContext.PersonCollection.Any()) return;

            var persons = new List<Person>
            {
                new Person
                {
                    FirstName = "Miles",
                    LastName = "DAVIS",
                    DateOfBirth = new DateTime(1940,4, 12),
                    BornIn = _cityRepository.Single("Toulon")
                },
                new Person
                {
                    FirstName = "Bill",
                    LastName = "EVANS",
                    DateOfBirth = new DateTime(1946,2, 24),
                    BornIn = _cityRepository.Single("Nice")
                },
                new Person
                {
                    FirstName = "Charlie",
                    LastName = "PARKER",
                    DateOfBirth = new DateTime(1936,12, 14),
                    BornIn = _cityRepository.Single("Toulon")
                }
            };
            persons.ForEach(city => _personRepository.Update(city));
            _personRepository.SaveChanges();
        }
    }
}
