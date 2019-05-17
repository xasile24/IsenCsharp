using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Context;

namespace Isen.DotNet.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Club>> GetTodoItem(int id)
        {
            var todoItem = await _context.ClubCollection.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Club>>> GetTodoItems()
        {
            return await _context.ClubCollection.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Club>> PostTodoItem(Club item)
        {
            _context.ClubCollection.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
        }
    }
}