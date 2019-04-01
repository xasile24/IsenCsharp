using System;
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Base;

namespace Isen.DotNet.Library.Repositories.inMemoryCityRepository
{
    public class inMemoryCityRepository :
        BaseInMemoryRepository<City>
    {
        //private List<City> _context;

        public override List<City> SampleData =>
            new List<City>()
            {
                new City() {Id = 1, Name = "Toulon", ZipCode = "83000"},
                new City() {Id = 2, Name = "Marseille", ZipCode = "13000"},
                new City() {Id = 3, Name = "Nice", ZipCode = "06000"},                    new City() {Id = 4, Name = "Paris", ZipCode = "75000"},
                new City() {Id = 5, Name = "Lyon", ZipCode = "69000"}
            };
    }
}