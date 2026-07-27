using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModels
{
    public class GameEditViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        [Required]
        public string PublisherName { get; set; } = string.Empty;

        [Required]
        public DateTime ReleasedOn { get; set; }

        [Required]
        public int GenreId { get; set; }
        public List<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();
    }
}
