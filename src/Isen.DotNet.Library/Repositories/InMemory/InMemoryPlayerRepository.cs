using System;
using System.Collections.Generic;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.InMemory
{
    public class InMemoryPlayerRepository :
        BaseInMemoryRepository<Player>,
        IPlayerRepository
    {
        private readonly IClubRepository _clubRepository;
        private readonly IHistoricRepository _historicRepository;
        // Pattern d'Injecttion de Dependance
        // aka IoC : Inversion of Control
        // aka DI : Dependency Injection
        public InMemoryPlayerRepository(
            IClubRepository clubRepository)
        {
            _clubRepository = clubRepository;
        }
        public override List<Player> SampleData =>
            new List<Player>()
            {
                new Player() {
                Id = 1,
                FirstName = "Sarah",
                LastName = "Bouhaddi",
                DateOfBirth = new DateTime(1986, 10, 17)
                },
                new Player() {
                Id = 2,
                FirstName = "Solène",
                LastName = "Durand",
                DateOfBirth = new DateTime(1994, 11, 20)
                },
                new Player() {
                Id = 3,
                FirstName = "Grace",
                LastName = "Geyoro",
                DateOfBirth = new DateTime(1997, 7, 2)
                }
            };
    }
}