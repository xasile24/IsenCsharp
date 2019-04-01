using System;
using System.Collections.Generic;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.inMemoryPersonRepository
{
    public class inMemoryPersonRepository :
        BaseInMemoryRepository<Person>,
        IPersonRepository
    {
        public override List<Person> SampleData =>
            new List<Person>()
            {
                new Person() {
                Id = 1,
                FirstName = "Jhon",
                LastName = "Doe",
                DateOfBirth = new DateTime(1964, 12, 4),
                },
                new Person() {
                Id = 2,
                FirstName = "Robert",
                LastName = "Second",
                DateOfBirth = new DateTime(1924, 11, 8),
                },
                new Person() {
                Id = 3,
                FirstName = "Jean",
                LastName = "Edward",
                DateOfBirth = new DateTime(1958, 11, 8),
                }
            };
    }
}