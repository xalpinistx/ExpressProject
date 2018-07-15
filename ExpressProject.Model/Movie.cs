using System.Collections.Generic;

namespace ExpressProject.Model
{
    public class Movie
    {
        public int? MovieId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ReleaseDate { get; set; }

        public string Director { get; set; }

        public double? Budget { get; set; }

        public string AgeLimit { get; set; }
        public string Length { get; set; }

        public double WorldWideGross { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
