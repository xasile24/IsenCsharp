using System;
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.InMemory
{
    public class InMemoryPersonRepository :
        BaseInMemoryRepository<Person>,
        IPersonRepository
    {   
        private readonly ICityRepository _cityRepository;
        
        // Pattern d'Injection de Dépendance
        // aka IoC : Inversion of Control
        // aka DI : Dependency Injection
        public InMemoryPersonRepository(
            ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public override List<Person> SampleData =>
            new List<Person>()
            {
                new Person()
                { 
                    Id = 1, 
                    FirstName = "Miles", 
                    LastName = "DAVIS", 
                    Name = "DAVIS Miles",
                    DateOfBirth = new DateTime(1926,5, 26),
                    BornIn = _cityRepository.Single("Toulon")
                },
                new Person()
                { 
                    Id = 2, 
                    FirstName = "Bill", 
                    LastName = "EVANS", 
                    Name = "EVANS Bill",
                    DateOfBirth = new DateTime(1929,8, 16),
                    BornIn = _cityRepository.Single("Nice")
                },
                new Person()
                { 
                    Id = 3, 
                    FirstName = "John", 
                    LastName = "COLTRANE", 
                    Name = "COLTRANE John",
                    DateOfBirth = new DateTime(1926, 9, 26),
                    BornIn = _cityRepository.Single("Lyon")
                }
            };
    }
}