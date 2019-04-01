using System;
using Isen.DotNet.Library;
using Isen.DotNet.Library.Lists;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.inMemoryCityRepository;
using Isen.DotNet.Library.Repositories.InMemoryPersonRepository;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ICityRepository cityRepo =
                new inMemoryCityRepository();
            IPersonRepository persoRepo = 
                new InMemoryPersonRepository(cityRepo);

            foreach(var p in persoRepo.Context)
                Console.WriteLine(p);
            
            var toulon = cityRepo.Single("Toulon");
            toulon.Name = "New York";
            cityRepo.Update(toulon);
            cityRepo.SaveChanges();

            foreach(var p in persoRepo.Context)
                Console.WriteLine(p);
        }
    }
}
