using System.Linq;
using Advanced.Web.EF;
using Advanced.Web.Models.ViewModels;
using Advanced.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Advanced.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        private ToggleService _toggleService;

        public HomeController(DataContext context, ToggleService toggleService)
        {
            _context = context;
            _toggleService = toggleService;
        }

        public IActionResult Index([FromQuery] string selectedCity)
        {
            return View(new PeopleListViewModel
            {
                People = _context.People
                    .Include(p => p.Department)
                    .Include(p => p.Location),
                Cities = _context.Locations.Select(l => l.City).Distinct(),
                SelectedCity = selectedCity
            });
        }

        public string Toggle()
        {
            return $"Enabled: {_toggleService.ToggleComponents()}";
        }
    }
}
