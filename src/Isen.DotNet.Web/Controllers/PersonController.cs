using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Isen.DotNet.Web.Controllers
{
    public class PersonController : BaseController<Person, IPersonRepository>
    {
        public PersonController(IPersonRepository repository) : base(repository)
        {
        }
    }
}