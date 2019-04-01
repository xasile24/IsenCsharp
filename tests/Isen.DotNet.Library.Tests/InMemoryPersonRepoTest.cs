using System;
using Xunit;
using System.Linq;
using Isen.DotNet.Library.Lists;
using System.Collections.Generic;
using Isen.DotNet.Library.Repositories.InMemoryPersonRepository;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Tests
{
    public class InMemoryPersonRepoTest
    {
        public class PersonRepoFactory
        {
            public static IPersonRepository Create() =>
                new InMemoryPersonRepository();
        }

        [Fact]
        public void SingleById()
        {
            var personRepo = PersonRepoFactory.Create();
            var person1 = personRepo.Single(1);
            Assert.True(person1.Id == 1);

            var noperson = personRepo.Single(42);
            Assert.True(noperson == null);

        }

        [Fact]
        public void SingleByName()
        {
            var personRepo = PersonRepoFactory.Create();
            var jhon = personRepo.Single("Jhon Doe");
            Assert.True(jhon.Name.Equals("Jhon Doe"));

            var fake = personRepo.Single("Ongle pomme");
            Assert.True(fake == null);
        }

        [Fact]
        public void UpdateUpdate()
        {
            var personRepo = PersonRepoFactory.Create();
            var initialCount = personRepo.Context
                .ToList()
                .Count();
            var jhon = personRepo.Single("Jhon Doe");
            jhon.Name = "Jhon Cena";
            personRepo.Update(jhon);
            personRepo.SaveChanges();
            var finalCount = personRepo.Context
                .ToList()
                .Count();

            var jhonUpdated = personRepo.Single(jhon.Id);
            Assert.True(jhonUpdated.Name == "Jhon Cena");
            //Assert.True(jhonUpdated.ZipCode == "83200");
            Assert.True(initialCount == finalCount);
        }

        [Fact]
        public void UpdateCreate()
        {
            var personRepo = PersonRepoFactory.Create();
            var initialCount = personRepo.Context
                .ToList()
                .Count();
            var gap = new Person()
            {
                FirstName = "Test",
                LastName = "Person",
                DateOfBirth = new DateTime(1994, 11, 8),
            };
            personRepo.Update(gap);
            personRepo.SaveChanges();
            var finalCount = personRepo.Context
                .ToList()
                .Count();
            Assert.True(initialCount == finalCount-1);

            var gapCreated = personRepo.Single("Test Person");
            Assert.True(gapCreated != null);
            //Assert.True(gapCreated.ZipCode == "05000");
            Assert.True(!gapCreated.isNew());
        }

        [Fact]
        public void Delete()
        {
            var personRepo = PersonRepoFactory.Create();
            var initialCount = personRepo.Context
                .ToList()
                .Count();
            
            var jhon = personRepo.Single("Jhon Doe");
            personRepo.Delete(jhon);
            personRepo.SaveChanges();

            var finalCount = personRepo.Context
                .ToList()
                .Count();

            Assert.True(initialCount == finalCount+1);
            Assert.True(personRepo.Single("Jhon Doe") == null);
        }   

        [Fact]
        public void GetAll()
        {
            var personRepo = PersonRepoFactory.Create();
            var contextCount = personRepo.Context
                .ToList()
                .Count();
            var getAllCount = personRepo.GetAll()
            .ToList()
            .Count();
            Assert.True(contextCount == getAllCount);
        }

        [Fact]
        public void Find()
        {
            var personRepo = PersonRepoFactory.Create();
            var query = personRepo
                .Find(c => c.Name.Contains("e"));
            var result = query.ToList();

            var countPersonsFromQuery = 0;
            foreach(var c in personRepo.Context)
            {
                if(c.Name.Contains("e")) countPersonsFromQuery++;
            }

            Assert.True(result.Count == countPersonsFromQuery);
        }
    }
}