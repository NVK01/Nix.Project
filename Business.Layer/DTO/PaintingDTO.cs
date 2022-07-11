using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.DTO
{
    public class PaintingDTO
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
        
    }
}
