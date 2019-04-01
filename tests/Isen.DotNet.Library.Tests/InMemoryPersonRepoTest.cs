using System;
using Xunit;
using System.Linq;
using Isen.DotNet.Library.Lists;
using System.Collections.Generic;
using Isen.DotNet.Library.Repositories.InMemoryPersonRepository;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Interfaces;
using Isen.DotNet.Library.Repositories.inMemoryCityRepository;

namespace Isen.DotNet.Library.Tests
{
    public class InMemoryPersonRepoTest
    {
        public class PersonRepoFactory
        {
            public static IPersonRepository Create(
                ICityRepository cityRepository = null) =>
                    new InMemoryPersonRepository(cityRepository ??
                    new inMemoryCityRepository());
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

        [Fact]
        public void DiTest()
        {
            ICityRepository cityRepo = new inMemoryCityRepository();
            var personRepo = PersonRepoFactory.Create(cityRepo);

            Assert.True(
                personRepo
                    .Single("Jhon Doe")?.BornIn?.Name == "Toulon");

            var cityId = personRepo
                .Single("Jhon Doe")?.BornIn?.Id;
            var toulon = cityRepo.Single("Toulon");
            toulon.Name = "New York";
            cityRepo.Update(toulon);
            cityRepo.SaveChanges();

            Assert.True(
                personRepo
                    .Single("Jhon Doe")?.BornIn?.Name == "New York");
            var updatedCityId = personRepo
                .Single("Jhon Doe")?.BornIn?.Id;
            Assert.True(cityId == updatedCityId);
        }
    }
}