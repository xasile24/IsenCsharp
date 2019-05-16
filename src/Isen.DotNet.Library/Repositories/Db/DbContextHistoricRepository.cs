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
    public  class DbContextHistoricRepository : 
        BaseDbRepository<Historic>,
        IHistoricRepository
    {
        public DbContextHistoricRepository(
            ApplicationDbContext dbContext) :
            base(dbContext)
        {
        }
        public override IQueryable<Historic> Includes(IQueryable<Historic> includes)
        {
            var inc = base.Includes(includes);
            inc = inc.Include(e => e.HPlayIn);
            inc = inc.Include(e => e.HPlayer);
            return inc;
        }
    }
}