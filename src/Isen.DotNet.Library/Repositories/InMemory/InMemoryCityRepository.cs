using System.Collections.Generic;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.InMemory
{
    public class InMemoryCityRepository :
        BaseInMemoryRepository<City>,
        ICityRepository
    {
        public override List<City> SampleData =>
            new List<City>()
            {
                new City() {Id = 1, Name = "Toulon", ZipCode = "83000"},
                new City() {Id = 2, Name = "Marseille", ZipCode = "13000"},
                new City() {Id = 3, Name = "Nice", ZipCode = "06000"},                    
                new City() {Id = 4, Name = "Paris", ZipCode = "75000"},
                new City() {Id = 5, Name = "Lyon", ZipCode = "69000"}
            };
    }
}