using System;
using System.Collections.Generic;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.InMemoryPersonRepository
{
    public class InMemoryPersonRepository :
        BaseInMemoryRepository<Person>,
        IPersonRepository
    {
        private readonly ICityRepository _cityRepository;

        // Pattern d'Injecttion de Dependance
        // aka IoC : Inversion of Control
        // aka DI : Dependency Injection
        public InMemoryPersonRepository(
            ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public InMemoryPersonRepository(){}
        public override List<Person> SampleData =>
            new List<Person>()
            {
                new Person() {
                Id = 1,
                FirstName = "Jhon",
                LastName = "Doe",
                DateOfBirth = new DateTime(1964, 12, 4),
                BornIn = _cityRepository.Single(1)
                },
                new Person() {
                Id = 2,
                FirstName = "Robert",
                LastName = "Second",
                DateOfBirth = new DateTime(1924, 11, 8),
                BornIn = _cityRepository.Single(2)
                },
                new Person() {
                Id = 3,
                FirstName = "Jean",
                LastName = "Edward",
                DateOfBirth = new DateTime(1958, 11, 8),
                BornIn = _cityRepository.Single(3)
                }
            };
    }
}