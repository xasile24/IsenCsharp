using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Isen.DotNet.Web.Controllers
{
    public class PlayerController : BaseController<Player, IPlayerRepository>
    {
        public PlayerController(IPlayerRepository repository) : base(repository)
        {
        }
    }
}