using System;
using Xunit;
using Isen.DotNet.Library.Lists;
using System.Collections.Generic;
using Isen.DotNet.Library.Repositories.InMemory;
using System.Linq;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Tests
{
    public class PersonRepoFactory
    {
        public static IPersonRepository Create(
            ICityRepository cityRepository = null) =>
                new InMemoryPersonRepository(cityRepository ?? 
                    new InMemoryCityRepository());           
    }

    public class InMemoryPersonRepoTest
    {
        [Fact]
        public void SingleById()
        {
            var personRepo = PersonRepoFactory.Create();
            
            var person1 = personRepo.Single(1);
            Assert.True(person1.Id == 1);

            var noPerson = personRepo.Single(42);
            Assert.True(noPerson == null);      
        }

        [Fact]
        public void SingleByName()
        {
            var personRepo = PersonRepoFactory.Create();

            var miles = personRepo.Single("DAVIS Miles");
            Assert.True(miles.Name == "DAVIS Miles");

            var fake = personRepo.Single("Fake");
            Assert.True(fake == null);
        }

        [Fact]
        public void UpdateUpdate()
        {
            var personRepo = PersonRepoFactory.Create();
            var initialCount = personRepo.Context
                .ToList()
                .Count();
                
            var miles = personRepo.Single("DAVIS Miles");
            miles.LastName = "DAVIS Jr.";
            miles.DateOfBirth = new DateTime(1980, 1, 2);

            personRepo.Update(miles);
            personRepo.SaveChanges();

            var FinalCount = personRepo.Context
                .ToList()
                .Count();

            var milesUpdated = 
                personRepo.Single(miles.Id);
            Assert.True(milesUpdated.LastName == "DAVIS Jr.");
            Assert.True(milesUpdated.DateOfBirth == new DateTime(1980, 1, 2));
            Assert.True(initialCount == FinalCount);
        }

        [Fact]
        public void UpdateCreate()
        {
            var personRepo = PersonRepoFactory.Create();
            var initialCount = personRepo.Context
                .ToList()
                .Count();

            var parker = new Person() 
            {
                FirstName = "Charlie",
                LastName = "PARKER",
                Name = "PARKER Charlie",
                DateOfBirth = new DateTime(1920, 8, 29)
            };
            personRepo.Update(parker);
            personRepo.SaveChanges();

            var FinalCount = personRepo.Context
                .ToList()
                .Count();
            Assert.True(initialCount == FinalCount - 1);

            var parkerCreated = personRepo.Single("PARKER Charlie");
            Assert.True(parkerCreated != null);
            Assert.True(parkerCreated.Name == "PARKER Charlie");
            Assert.True(!parkerCreated.IsNew);
        }

        [Fact]
        public void Delete()
        {
            var personRepo = PersonRepoFactory.Create();
            var initialCount = personRepo.Context
                .ToList()
                .Count();

            var miles = personRepo.Single("DAVIS Miles");
            personRepo.Delete(miles);
            personRepo.SaveChanges();
            var finalCount = personRepo.Context
                .ToList()
                .Count();

            Assert.True(finalCount == initialCount - 1);
            Assert.True(personRepo.Single("DAVIS Miles") == null);
        }

        [Fact]
        public void GetAll()
        {
            var personRepo = PersonRepoFactory.Create();
            var contextCount = personRepo.Context
                .ToList()
                .Count();
            
            var getAllCount = personRepo
                .GetAll()
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

            var countCitiesFromQuery = 0;
            foreach(var c in personRepo.Context.ToList())
            {
                if(c.Name.Contains("e"))
                    countCitiesFromQuery++;
            }
            Assert.True(result.Count == countCitiesFromQuery);
        }

        [Fact]
        public void DiTest()
        {
            ICityRepository cityRepo = new InMemoryCityRepository();
            var personRepo = PersonRepoFactory.Create(cityRepo);

            Assert.True(
                personRepo
                    .Single("DAVIS Miles")?.BornIn?.Name == "Toulon");
            var cityId = personRepo
                    .Single("DAVIS Miles")?.BornIn?.Id;
            var toulon = cityRepo.Single("Toulon");
            toulon.Name = "New York";
            cityRepo.Update(toulon);
            cityRepo.SaveChanges();

            Assert.True(
                personRepo
                    .Single("DAVIS Miles")?.BornIn?.Name == "New York");
            var updatedCityId = personRepo
                    .Single("DAVIS Miles")?.BornIn?.Id;

            Assert.True(cityId == updatedCityId);
        }
    }
}