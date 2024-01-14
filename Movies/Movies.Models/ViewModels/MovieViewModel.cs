using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models.ViewModels
{
    public class MovieViewModel
    {
        public DateTime? ReleaseDate { get; set; }
        public string? Title { get; set; }
        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public int? VoteCount { get; set; }
        public double? VoteAverage { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? Genre { get; set; }
        public string? PosterUrl { get; set; }
    }
}
