using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExpressProject.Api.Models
{
    public class MovieViewModel
    {
        public int? MovieId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Date of release")]
        public string ReleaseDate { get; set; }

        public string Director { get; set; }

        public double? Budget { get; set; }

        [Required]
        [Display(Name = "Rate")]
        public string AgeLimit { get; set; }

        [Required]
        public string Length { get; set; }

        [Display(Name = "World Wide Gross")]
        public double WorldWideGross { get; set; }
    }
}