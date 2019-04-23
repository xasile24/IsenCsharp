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
        private readonly ICityRepository _repository;

        public CityController()
        {
            _repository = new InMemoryCityRepository();
        }
        public IActionResult Index() => View(_repository.GetAll());

        public IActionResult Edit(int? id)
        {
            if (id == null) return View();
            return View(_repository.Single(id.Value));
        }
    }
}
