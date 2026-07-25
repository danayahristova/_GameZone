using GameZone.Data;
using GameZone.Data.Models;
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
            var games = _context.Games
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
        [HttpGet]
        public IActionResult Add()
        {
            var genres = _context.Genres.ToList();
            var model = new GameAddViewModel
            {
                Genres = genres
                    .Select(g => new GenreViewModel { Id = g.Id, Name = g.Name })
                    .ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(GameAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Genres = _context.Genres
                    .Select(g => new GenreViewModel 
                        { 
                            Id = g.Id,
                            Name = g.Name 
                    }).ToList();

                return View(model);
            }
            var game = new Game
            {
                Title = model.Title,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PublisherName = model.PublisherName,
                ReleasedOn = model.ReleasedOn,
                GenreId = model.GenreId
            };
            _context.Games.Add(game);
            _context.SaveChanges();
            return RedirectToAction("All");
        }
        public IActionResult Details(int id)
        {
            var game = _context.Games
                .Select(g => new GameDetailsViewModel
                {
                    Id = g.Id,
                    Title = g.Title,
                    Description = g.Description,
                    ImageUrl = g.ImageUrl,
                    Publisher = g.PublisherName,
                    ReleasedOn = g.ReleasedOn,
                    GenreId = g.GenreId,
                    Genre = g.Genre.Name
                })
                .FirstOrDefault(g => g.Id == id);

            return game is not null ? View(game) : NotFound();
        }
    }
}
