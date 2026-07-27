using GameZone.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Data.Models
{
    public class Game
    {
        [Key]
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

        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;
    }
}
