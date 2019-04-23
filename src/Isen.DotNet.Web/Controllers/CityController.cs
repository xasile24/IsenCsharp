using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Isen.DotNet.Web.Models;
using Isen.DotNet.Library.Repositories.Interfaces;
using Isen.DotNet.Library.Repositories.InMemory;

namespace Isen.DotNet.Web.Controllers
{
    public class CityController : Controller
    {
        public IActionResult Index()
        {
            ICityRepository cityRepository = 
                new InMemoryCityRepository();
            var list = cityRepository.GetAll();

            return View(list);
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
