using System;
using System.Collections.Generic;
using Isen.DotNet.Library;
using Isen.DotNet.Library.Lists;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.InMemory;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ICityRepository cityRepo = 
                new InMemoryCityRepository();
            IPersonRepository personRepo = 
                new InMemoryPersonRepository(cityRepo);

            foreach(var p in personRepo.Context)
                Console.WriteLine(p);

            var toulon = cityRepo.Single("Toulon");
            toulon.Name = "New York";
            cityRepo.Update(toulon);
            cityRepo.SaveChanges();

            foreach(var p in personRepo.Context)
                Console.WriteLine(p);
        }
    }
}
