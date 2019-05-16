using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;

namespace Isen.DotNet.Library.Context
{
    public class SeedData
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICityRepository _cityRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IClubRepository _clubRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IHistoricRepository _historicRepository;

        public SeedData(
            ApplicationDbContext dbContext,
            ICityRepository cityRepository,
            IPersonRepository personRepository,
            IClubRepository clubRepository,
            IPlayerRepository playerRepository,
            IHistoricRepository historicRepository)
        {
            _dbContext = dbContext;
            _cityRepository = cityRepository;
            _personRepository = personRepository;
            _clubRepository = clubRepository;
            _playerRepository = playerRepository;
            _historicRepository = historicRepository;
        }

        public void DropCreateDatabase()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }

        public void AddCities()
        {
            // Ne rien faire s'il y a déjà des villes
            if (_dbContext.CityCollection.Any()) return;

            var cities = new List<City>
            {
                new City { Name = "Toulon", ZipCode = "83000" },
                new City { Name = "Marseille", ZipCode = "13000" },
                new City { Name = "Nice", ZipCode = "06000" },
                new City { Name = "Lyon", ZipCode = "69000" }
            };
            cities.ForEach(city => _cityRepository.Update(city));
            _cityRepository.SaveChanges();
        }

        public void AddPersons()
        {
            // Ne rien faire si non vide
            if(_dbContext.PersonCollection.Any()) return;

            var persons = new List<Person>
            {
                new Person
                {
                    FirstName = "Miles",
                    LastName = "DAVIS",
                    DateOfBirth = new DateTime(1940,4, 12),
                    BornIn = _cityRepository.Single("Toulon")
                },
                new Person
                {
                    FirstName = "Bill",
                    LastName = "EVANS",
                    DateOfBirth = new DateTime(1946,2, 24),
                    BornIn = _cityRepository.Single("Nice")
                },
                new Person
                {
                    FirstName = "Charlie",
                    LastName = "PARKER",
                    DateOfBirth = new DateTime(1936,12, 14),
                    BornIn = _cityRepository.Single("Toulon")
                }
            };
            persons.ForEach(city => _personRepository.Update(city));
            _personRepository.SaveChanges();
        }
        public void AddClubs()
        {
            if (_dbContext.ClubCollection.Any()) return;

            var clubs = new List<Club>
            {
                new Club() { Name = "EA Guingamp", logo="~/images/EA_Guingamp.png", latitude=10, longitude=20},
                new Club() { Name = "Olympique lyonnais", logo="~/images/Olympique_lyonnais.png", latitude=30, longitude=40},
                new Club() { Name = "Paris Saint-Germain", logo="~/images/Paris_Saint-Germain.png", latitude=50, longitude=60},
                new Club() { Name = "Dijon fco", logo="~/images/Dijon_FCO.png", latitude=70, longitude=80},
                new Club() { Name = "Montpellier HSC", logo="~/images/Montpellier_HSC.png", latitude=90, longitude=100}
            };
            clubs.ForEach(club => _clubRepository.Update(club));
            _clubRepository.SaveChanges();
        }

        public void AddPlayers()
        {
            if (_dbContext.PlayerCollection.Any()) return;

            var players = new List<Player>
            {
               new Player() {
                FirstName = "Sarah",
                LastName = "Bouhaddi",
                DateOfBirth = new DateTime(1986, 10, 17)
                },
                new Player() {
                FirstName = "Solène",
                LastName = "Durand",
                DateOfBirth = new DateTime(1994, 11, 20)
                },
                new Player() {
                FirstName = "Grace",
                LastName = "Geyoro",
                DateOfBirth = new DateTime(1997, 7, 2)
                }
            };
            players.ForEach(player => _playerRepository.Update(player));
            _playerRepository.SaveChanges();
        }

        public void AddHistorics()
        {
            if (_dbContext.HistoricCollection.Any()) return;

            var historics = new List<Historic>
            {
                new Historic()
                { 
                    Name = "Sarah Bouhaddi 1",
                    StartDate = new DateTime(2012,5, 26),
                    EndDate = new DateTime(2015,5, 26),
                    HPlayer = _playerRepository.Single("Sarah Bouhaddi"),
                    HPlayIn = _clubRepository.Single("EA Guingamp")
                },
                new Historic()
                { 
                    Name = "Sarah Bouhaddi 2",
                    StartDate = new DateTime(2005,5, 16),
                    EndDate = new DateTime(2006,8, 16),
                    HPlayer = _playerRepository.Single("Sarah Bouhaddi"),
                    HPlayIn = _clubRepository.Single("Olympique lyonnais")
                },
                new Historic()
                { 
                    Name = "Sarah Bouhaddi 3",
                    StartDate = new DateTime(2008,11, 3),
                    EndDate = new DateTime(2011,10, 5),
                    HPlayer = _playerRepository.Single("Sarah Bouhaddi"),
                    HPlayIn = _clubRepository.Single("EA Guingamp")
                }
            };
            historics.ForEach(historic => _historicRepository.Update(historic));
            _historicRepository.SaveChanges();
        }
    }
}
