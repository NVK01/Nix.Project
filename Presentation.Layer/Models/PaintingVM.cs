using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nix.Project.Models
{
    public class PaintingVM
    {
        public string? PaintingId { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string? Name { get; set; }
        [Required]
        [StringLength(5, MinimumLength = 0)]
        public string? Subject { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 0)]
        public string? Style { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 0)]
        public string? Medium { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public string? Size { get; set; }
        [Required]
        public string? ImgURL { get; set; }

        [StringLength(30, MinimumLength = 0)]
        public string? Autor { get; set; }

        [StringLength(200, MinimumLength = 0)]
        public string? About { get; set; }

        public string? ApplicationUserId { get; set; }
        [NotMapped]
        public IFormFile? FormFile { get; set; }
    }
}
