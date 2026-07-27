using GameZone.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.ViewModels
{
    public class GameListViewModel
    {

        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        [Required]
        public string Publisher { get; set; } = string.Empty;

        [Required]
        public DateTime ReleasedOn { get; set; }

        [Required]
        public int GenreId { get; set; }

        public GenreViewModel Genre{ get; set; } = null!;
    }
}
