using MicroserviceDemoWithDocker.Data;
using MicroserviceDemoWithDocker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceDemoWithDocker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonDbContext _context;

        public PersonController(PersonDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async ValueTask<IActionResult> Get()
        {
            var result = await _context.People.ToArrayAsync();
            return Ok(result);
        }
        [HttpPost]
        public async ValueTask<IActionResult> Create(Person person)
        {
            await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }
    }
}
