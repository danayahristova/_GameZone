using System.ComponentModel.DataAnnotations;
using GameZone.Common;
namespace GameZone.ViewModels
{
    public class GameEditViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(ValidationConstants.EventTitleMinLength)]
        [MaxLength(ValidationConstants.EventTitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(ValidationConstants.GameDescriptonMaxLength)]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        [Required]
        [MinLength(ValidationConstants.PublisherNameMinLength)]
        [MaxLength(ValidationConstants.PublisherNameMaxLength)]
        public string PublisherName { get; set; } = string.Empty;

        [Required]
        public DateTime ReleasedOn { get; set; }

        [Required]
        public int GenreId { get; set; }
        public List<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();
    }
}
