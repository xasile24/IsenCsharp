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
            
            IClubRepository clubRepo = 
                new InMemoryClubRepository();
            IPlayerRepository playerRepo = 
                new InMemoryPlayerRepository(clubRepo);
            IHistoricRepository historicRepo = 
                new InMemoryHistoricRepository(clubRepo, playerRepo); 


            /* 
            foreach(var p in playerRepo.Context)
                Console.WriteLine(p);

            foreach(var h in historicRepo.Context)
                Console.WriteLine(h);*/

            /*
            Player playerTest = playerRepo.Single(1);
            List<Historic> listH = playerTest.HistoricCollection;*/

            /*var toulon = clubRepo.Single("Toulon");
            toulon.Name = "New York";
            clubRepo.Update(toulon);
            clubRepo.SaveChanges();

            foreach(var p in playerRepo.Context)
                Console.WriteLine(p);*/
        }
    }
}
