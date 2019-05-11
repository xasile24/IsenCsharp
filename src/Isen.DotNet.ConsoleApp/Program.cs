using System;
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
            /*ICityRepository cityRepo =
                new InMemoryCityRepository();
            IPersonRepository persoRepo = 
                new InMemoryPersonRepository(cityRepo);*/
            IClubRepository clubRepo = 
                new InMemoryClubRepository();

            foreach(var p in clubRepo.Context)
                Console.WriteLine(p);
            
            /*var toulon = cityRepo.Single("Toulon");
            toulon.Name = "New York";
            cityRepo.Update(toulon);
            cityRepo.SaveChanges();*/
        }
    }
}
