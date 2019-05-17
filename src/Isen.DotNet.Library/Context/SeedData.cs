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
        private readonly IClubRepository _clubRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly IHistoricRepository _historicRepository;

        public SeedData(
            ApplicationDbContext dbContext,
            IClubRepository clubRepository,
            IPlayerRepository playerRepository,
            IHistoricRepository historicRepository)
        {
            _dbContext = dbContext;
            _clubRepository = clubRepository;
            _playerRepository = playerRepository;
            _historicRepository = historicRepository;
        }

        public void DropCreateDatabase()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }

        public void AddClubs()
        {
            if (_dbContext.ClubCollection.Any()) return;

            var clubs = new List<Club>
            {
                new Club() { Name = "EA Guingamp", address = "15, boulevard Clemenceau 22202 Guingamp", logo="/images/EA_Guingamp.png", latitude=10, longitude=20},
                new Club() { Name = "Olympique lyonnais", address = "Parc OL, 10 avenue Simone Veil, 69150 Décines-Charpieu",  logo="/images/Olympique_lyonnais.png", latitude=30, longitude=40},
                new Club() { Name = "Paris Saint-Germain", address = "24 Rue du Commandant-Guilbaud 75016 Paris",  logo="/images/Paris_Saint-Germain.png", latitude=50, longitude=60},
                new Club() { Name = "Dijon fco", address = "9 rue Ernest Champeaux, 21000 Dijon",  logo="/images/Dijon_FCO.png", latitude=70, longitude=80},
                new Club() { Name = "Arsenal Ladies FC", address = "Highbury House 75 Drayton Park, London N5 1BU",  logo="/images/Arsenal_Ladies_FC.png", latitude=90, longitude=100},
                new Club() { Name = "Atlético de Madrid", address = "Madrid",  logo="/images/Atlético_de_Madrid.png", latitude=90, longitude=100},
                new Club() { Name = "FC Fleury 91", address = "8 Place Louis Aragon 91700 Fleury-Mérogis",  logo="/images/FC_Fleury_91.png", latitude=90, longitude=100},
                new Club() { Name = "Girondins de Bordeaux", address = "Château du Haillan",  logo="/images/Girondins_de_Bordeaux.png", latitude=90, longitude=100},
                new Club() { Name = "Paris FC", address = "17 rue Neuve-Tolbiac 75013 Paris",  logo="/images/Paris_FC.png", latitude=90, longitude=100},
                new Club() { Name = "Montpellier HSC", address = "Domaine de Grammont Avenue Albert Einstein 34070 Montpellier",  logo="/images/Montpellier_HSC.png", latitude=90, longitude=100}
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
                },
                new Player() {
                FirstName = "Peyraud",
                LastName = "Magnin",
                DateOfBirth = new DateTime(1991, 5, 17)
                },
                new Player() {
                FirstName = "Julie",
                LastName = "Debever",
                DateOfBirth = new DateTime(1988, 9, 20)
                },
                new Player() {
                FirstName = "Sakina",
                LastName = "Karchaoui",
                DateOfBirth = new DateTime(1995, 10, 10)
                },
                new Player() {
                FirstName = "Amel",
                LastName = "Majri",
                DateOfBirth = new DateTime(1986, 8, 25)
                },
                new Player() {
                FirstName = "Griedge",
                LastName = "Mbock",
                DateOfBirth = new DateTime(1994, 4, 4)
                },
                new Player() {
                FirstName = "Eve",
                LastName = "Perisset",
                DateOfBirth = new DateTime(1990, 1, 22)
                },
                new Player() {
                FirstName = "Wendy",
                LastName = "Renard",
                DateOfBirth = new DateTime(1988, 2, 18)
                },
                new Player() {
                FirstName = "Marion",
                LastName = "Torrent",
                DateOfBirth = new DateTime(1991, 11, 15)
                },
                new Player() {
                FirstName = "Elise",
                LastName = "Bussaglia",
                DateOfBirth = new DateTime(1992, 5, 2)
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
                    Name = "11",
                    StartDate = new DateTime(2009,5, 26),
                    EndDate = new DateTime(2015,5, 26),
                    HPlayer = _playerRepository.Single("Grace Geyoro"),
                    HPlayIn = _clubRepository.Single("EA Guingamp")
                },
                new Historic()
                { 
                    Name = "12",
                    StartDate = new DateTime(2005,5, 16),
                    EndDate = new DateTime(2009,8, 16),
                    HPlayer = _playerRepository.Single("Wendy Renard"),
                    HPlayIn = _clubRepository.Single("Olympique lyonnais")
                },
                new Historic()
                { 
                    Name = "13",
                    StartDate = new DateTime(2012,11, 3),
                    EndDate = new DateTime(2014,10, 5),
                    HPlayer = _playerRepository.Single("Griedge Mbock"),
                    HPlayIn = _clubRepository.Single("FC Fleury 91")
                },
                new Historic()
                { 
                    Name = "14",
                    StartDate = new DateTime(2012,5, 26),
                    EndDate = new DateTime(2013,8, 26),
                    HPlayer = _playerRepository.Single("Wendy Renard"),
                    HPlayIn = _clubRepository.Single("Girondins de Bordeaux")
                },
                new Historic()
                { 
                    Name = "15",
                    StartDate = new DateTime(2004,5, 16),
                    EndDate = new DateTime(2006,8, 16),
                    HPlayer = _playerRepository.Single("Elise Bussaglia"),
                    HPlayIn = _clubRepository.Single("Olympique lyonnais")
                },
                new Historic()
                { 
                    Name = "16",
                    StartDate = new DateTime(2008,11, 3),
                    EndDate = new DateTime(2012,10, 5),
                    HPlayer = _playerRepository.Single("Elise Bussaglia"),
                    HPlayIn = _clubRepository.Single("Paris Saint-Germain")
                },
                new Historic()
                { 
                    Name = "17",
                    StartDate = new DateTime(2012,5, 26),
                    EndDate = new DateTime(2015,5, 26),
                    HPlayer = _playerRepository.Single("Amel Majri"),
                    HPlayIn = _clubRepository.Single("Girondins de Bordeaux")
                },
                new Historic()
                { 
                    Name = "18",
                    StartDate = new DateTime(2005,5, 16),
                    EndDate = new DateTime(2008,8, 16),
                    HPlayer = _playerRepository.Single("Sakina Karchaoui"),
                    HPlayIn = _clubRepository.Single("Arsenal Ladies FC")
                },
                new Historic()
                { 
                    Name = "19",
                    StartDate = new DateTime(2008,11, 3),
                    EndDate = new DateTime(2018,10, 5),
                    HPlayer = _playerRepository.Single("Eve Perisset"),
                    HPlayIn = _clubRepository.Single("EA Guingamp")
                },
                new Historic()
                { 
                    Name = "110",
                    StartDate = new DateTime(2012,5, 26),
                    EndDate = new DateTime(2016,5, 26),
                    HPlayer = _playerRepository.Single("Julie Debever"),
                    HPlayIn = _clubRepository.Single("Paris Saint-Germain")
                },
                new Historic()
                { 
                    Name = "111",
                    StartDate = new DateTime(2002,5, 16),
                    EndDate = new DateTime(2006,8, 16),
                    HPlayer = _playerRepository.Single("Eve Perisset"),
                    HPlayIn = _clubRepository.Single("Olympique lyonnais")
                },
                new Historic()
                { 
                    Name = "112",
                    StartDate = new DateTime(2008,11, 3),
                    EndDate = new DateTime(2011,10, 5),
                    HPlayer = _playerRepository.Single("Marion Torrent"),
                    HPlayIn = _clubRepository.Single("Paris FC")
                },
                new Historic()
                { 
                    Name = "113",
                    StartDate = new DateTime(2012,5, 26),
                    EndDate = new DateTime(2013,5, 26),
                    HPlayer = _playerRepository.Single("Marion Torrent"),
                    HPlayIn = _clubRepository.Single("Dijon fco")
                },
                new Historic()
                { 
                    Name = "114",
                    StartDate = new DateTime(2008,5, 16),
                    EndDate = new DateTime(2010,8, 16),
                    HPlayer = _playerRepository.Single("Solène Durand"),
                    HPlayIn = _clubRepository.Single("Arsenal Ladies FC")
                },
                new Historic()
                { 
                    Name = "115",
                    StartDate = new DateTime(2002,11, 3),
                    EndDate = new DateTime(2011,10, 5),
                    HPlayer = _playerRepository.Single("Wendy Renard"),
                    HPlayIn = _clubRepository.Single("Dijon fco")
                },
                new Historic()
                { 
                    Name = "116",
                    StartDate = new DateTime(2011,5, 26),
                    EndDate = new DateTime(2015,5, 26),
                    HPlayer = _playerRepository.Single("Sarah Bouhaddi"),
                    HPlayIn = _clubRepository.Single("FC Fleury 91")
                },
                new Historic()
                { 
                    Name = "117",
                    StartDate = new DateTime(2005,5, 16),
                    EndDate = new DateTime(2006,8, 16),
                    HPlayer = _playerRepository.Single("Julie Debever"),
                    HPlayIn = _clubRepository.Single("Arsenal Ladies FC")
                },
                new Historic()
                { 
                    Name = "118",
                    StartDate = new DateTime(2008,11, 3),
                    EndDate = new DateTime(2011,10, 5),
                    HPlayer = _playerRepository.Single("Peyraud Magnin"),
                    HPlayIn = _clubRepository.Single("Arsenal Ladies FC")
                },
                new Historic()
                { 
                    Name = "119",
                    StartDate = new DateTime(2012,5, 26),
                    EndDate = new DateTime(2015,5, 26),
                    HPlayer = _playerRepository.Single("Peyraud Magnin"),
                    HPlayIn = _clubRepository.Single("EA Guingamp")
                },
                new Historic()
                { 
                    Name = "120",
                    StartDate = new DateTime(2005,5, 16),
                    EndDate = new DateTime(2006,8, 16),
                    HPlayer = _playerRepository.Single("Sarah Bouhaddi"),
                    HPlayIn = _clubRepository.Single("Atlético de Madrid")
                },
                new Historic()
                { 
                    Name = "121",
                    StartDate = new DateTime(2008,11, 3),
                    EndDate = new DateTime(2011,10, 5),
                    HPlayer = _playerRepository.Single("Griedge Mbock"),
                    HPlayIn = _clubRepository.Single("Dijon fco")
                },
            };
            historics.ForEach(historic => _historicRepository.Update(historic));
            _historicRepository.SaveChanges();
        }
    }
}
