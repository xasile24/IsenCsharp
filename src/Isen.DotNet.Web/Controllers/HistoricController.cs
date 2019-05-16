using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Isen.DotNet.Web.Controllers
{
    public class HistoricController : BaseController<Historic, IHistoricRepository>
    {
        public HistoricController(IHistoricRepository repository) : base(repository)
        {
        }
    }
}