using System;
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.InMemory
{
    public class InMemoryClubRepository :
        BaseInMemoryRepository<Club>,
        IClubRepository
    {
        public override List<Club> SampleData =>
            new List<Club>()
            {
                new Club() {Id = 1, Name = "EA Guingamp", logo="aJ6JEi5sa52", latitude=10, longitude=20},
                new Club() {Id = 2, Name = "Olympique lyonnais", logo="iuef53eHEIJ", latitude=30, longitude=40},
                new Club() {Id = 3, Name = "Paris Saint-Germain", logo="izefn58eUEn", latitude=50, longitude=60},
                new Club() {Id = 4, Name = "Dijon FCO", logo="za6eJE526ad", latitude=70, longitude=80},
                new Club() {Id = 5, Name = "Montpelier HSC", logo="18NDIanda5dE", latitude=90, longitude=100}
            };
    }
}