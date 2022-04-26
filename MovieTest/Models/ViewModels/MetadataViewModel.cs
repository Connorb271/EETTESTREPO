using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTest.Models.ViewModels
{
    public class MetadataViewModel
    {
        public MetadataViewModel(Metadata metadata)
        {
            this.movieId = metadata.MovieId;
            this.title = metadata.Title;
            this.language = metadata.Language;
            this.duration = metadata.Duration.ToString();
            this.releaseYear = metadata.ReleaseYear;
        }
        public int movieId { get; set; }
        public string title { get; set; }
        public string language { get; set; }
        public string duration { get; set; }
        public int releaseYear { get; set; }
    }
}
