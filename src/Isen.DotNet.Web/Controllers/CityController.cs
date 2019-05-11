using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.InMemory;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Isen.DotNet.Web.Models;

namespace Isen.DotNet.Web.Controllers
{
    public class CityController : BaseController<City, ICityRepository>
    {
        public CityController(ICityRepository repository) : base(repository)
        {
        }
    }
}
