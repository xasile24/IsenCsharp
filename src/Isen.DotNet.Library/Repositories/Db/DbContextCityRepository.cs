using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Isen.DotNet.Library.Context;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Isen.DotNet.Library.Repositories.Db
{
    public class DbContextCityRepository : 
        BaseDbRepository<City>,
        ICityRepository
    {
        public DbContextCityRepository(
            ApplicationDbContext dbContext) : 
            base(dbContext)
        {
        }

        public override IQueryable<City> Includes(IQueryable<City> includes)
        {
            var inc = base.Includes(includes);
            inc = inc.Include(c => c.PersonCollection);
            return inc;
        }
    }
}
