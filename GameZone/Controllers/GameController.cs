using GameZone.Data;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Controllers
{
    public class GameController : Controller
    {
        private readonly GameZoneDbContext _context;
        public GameController(GameZoneDbContext context)
        {
            _context = context;
        }   
        public IActionResult All()
        {
            var games =  _context.Games
                .Select(g => new GameViewModel
                    {
                        Id = g.Id,
                        Title = g.Title,
                        Description = g.Description,
                        ImageUrl = g.ImageUrl,
                        Publisher = g.PublisherName,
                        ReleasedOn = g.ReleasedOn,
                        GenreId = g.GenreId
                    }).ToList();
            return View(games);
        }
    }
}
