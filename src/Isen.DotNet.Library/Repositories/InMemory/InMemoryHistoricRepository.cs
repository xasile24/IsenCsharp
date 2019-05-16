using System;
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.InMemory
{
    public class InMemoryHistoricRepository :
        BaseInMemoryRepository<Historic>,
        IHistoricRepository
    {   
        private readonly IClubRepository _clubRepository;
        private readonly IPlayerRepository _playerRepository;
        
        // Pattern d'Injection de Dépendance
        // aka IoC : Inversion of Control
        // aka DI : Dependency Injection
        public InMemoryHistoricRepository(
            IClubRepository clubRepository,
            IPlayerRepository playerRepository)
        {
            _clubRepository = clubRepository;
            _playerRepository = playerRepository;
        }

        public override List<Historic> SampleData =>
            new List<Historic>()
            {
                new Historic()
                { 
                    Id = 1, 
                    Name = "Sarah Bouhaddi 1",
                    StartDate = new DateTime(2012,5, 26),
                    EndDate = new DateTime(2015,5, 26),
                    HPlayIn = _clubRepository.Single("EA Guingamp"),
                    HPlayer = _playerRepository.Single("Sarah Bouhaddi")
                },
                new Historic()
                { 
                    Id = 2, 
                    Name = "Sarah Bouhaddi 2",
                    StartDate = new DateTime(2005,5, 16),
                    EndDate = new DateTime(2006,8, 16),
                    HPlayIn = _clubRepository.Single("Olympique lyonnais"),
                    HPlayer = _playerRepository.Single("Sarah Bouhaddi")
                },
                new Historic()
                { 
                    Id = 3, 
                    Name = "Sarah Bouhaddi 3",
                    StartDate = new DateTime(2008,11, 3),
                    EndDate = new DateTime(2011,10, 5),
                    HPlayIn = _clubRepository.Single("Dijon FCO"),
                    HPlayer = _playerRepository.Single("Sarah Bouhaddi")
                }
            };
    }
}