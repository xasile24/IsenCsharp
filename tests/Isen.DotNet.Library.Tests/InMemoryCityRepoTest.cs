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
    public class CityRepoFactory
    {
        public static ICityRepository Create() =>
            new InMemoryCityRepository();
    }
    public class InMemoryCityRepoTest
    {
        [Fact]
        public void SingleById()
        {
            var cityRepo = CityRepoFactory.Create();
            
            var city1 = cityRepo.Single(1);
            Assert.True(city1.Id == 1);

            var noCity = cityRepo.Single(42);
            Assert.True(noCity == null);      
        }

        [Fact]
        public void SingleByName()
        {
            var cityRepo = CityRepoFactory.Create();

            var toulon = cityRepo.Single("Toulon");
            Assert.True(toulon.Name == "Toulon");

            var fake = cityRepo.Single("Fake");
            Assert.True(fake == null);
        }

        [Fact]
        public void UpdateUpdate()
        {
            var cityRepo = CityRepoFactory.Create();
            var initialCount = cityRepo.Context
                .ToList()
                .Count();
                
            var toulon = cityRepo.Single("Toulon");
            toulon.Name = "Toulon sur Mer";
            toulon.ZipCode = "83200";

            cityRepo.Update(toulon);
            cityRepo.SaveChanges();

            var FinalCount = cityRepo.Context
                .ToList()
                .Count();

            var toulonUpdated = 
                cityRepo.Single(toulon.Id);
            Assert.True(toulonUpdated.Name == "Toulon sur Mer");
            Assert.True(toulonUpdated.ZipCode == "83200");
            Assert.True(initialCount == FinalCount);
        }

        [Fact]
        public void UpdateCreate()
        {
            var cityRepo = CityRepoFactory.Create();
            var initialCount = cityRepo.Context
                .ToList()
                .Count();

            var gap = new City() 
            {
                Name = "Gap",
                ZipCode = "05000"
            };
            cityRepo.Update(gap);
            cityRepo.SaveChanges();

            var FinalCount = cityRepo.Context
                .ToList()
                .Count();
            Assert.True(initialCount == FinalCount - 1);

            var gapCreated = cityRepo.Single("Gap");
            Assert.True(gapCreated != null);
            Assert.True(gapCreated.ZipCode == "05000");
            Assert.True(!gapCreated.IsNew);
        }

        [Fact]
        public void Delete()
        {
            var cityRepo = CityRepoFactory.Create();
            var initialCount = cityRepo.Context
                .ToList()
                .Count();

            var toulon = cityRepo.Single("Toulon");
            cityRepo.Delete(toulon);
            cityRepo.SaveChanges();
            var finalCount = cityRepo.Context
                .ToList()
                .Count();

            Assert.True(finalCount == initialCount - 1);
            Assert.True(cityRepo.Single("Toulon") == null);
        }

        [Fact]
        public void GetAll()
        {
            var cityRepo = CityRepoFactory.Create();
            var contextCount = cityRepo.Context
                .ToList()
                .Count();
            
            var getAllCount = cityRepo
                .GetAll()
                .ToList()
                .Count();

            Assert.True(contextCount == getAllCount);
        }

        [Fact]
        public void Find()
        {
            var cityRepo = CityRepoFactory.Create();
            var query = cityRepo
                .Find(c => c.Name.Contains("e"));
            var result = query.ToList();

            var countCitiesFromQuery = 0;
            foreach(var c in cityRepo.Context.ToList())
            {
                if(c.Name.Contains("e"))
                    countCitiesFromQuery++;
            }
            Assert.True(result.Count == countCitiesFromQuery);
        }
    }
}