using System.Collections.Generic;
using System.Threading.Tasks;
using Advanced.Web.EF;
using Advanced.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Advanced.Web.Controllers
{
    [ApiController]
    [Route("/api/people")]
    public class DataController : ControllerBase
    {
        private readonly DataContext _context;

        public DataController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Person> GetAll()
        {
            IEnumerable<Person> people = _context.People
                .Include(p => p.Department)
                .Include(p => p.Location);

            foreach (Person p in people)
            {
                p.Department.People = null;
                p.Location.People = null;
            }

            return people;
        }

        [HttpGet("{id}")]
        public async Task<Person> GetDetails(long id)
        {
            Person p = await _context.People
                .Include(p => p.Department)
                .Include(p => p.Location)
                .FirstAsync(p => p.PersonId == id);

            p.Department.People = null;
            p.Location.People = null;
            return p;
        }

        [HttpPost]
        public async Task Save([FromBody] Person p)
        {
            await _context.People.AddAsync(p);
            await _context.SaveChangesAsync();
        }

        [HttpPut]
        public async Task Update([FromBody] Person p)
        {
            _context.Update(p);
            await _context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            _context.People.Remove(new Person() {PersonId = id});
            await _context.SaveChangesAsync();
        }

        [HttpGet("/api/locations")]
        public IAsyncEnumerable<Location> GetLocations() => _context.Locations;

        [HttpGet("/api/departments")]
        public IAsyncEnumerable<Department> GetDepts() => _context.Departments;
    }
}
