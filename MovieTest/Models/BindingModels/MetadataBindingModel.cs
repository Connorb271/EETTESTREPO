using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTest.Models.BindingModels
{
    public class MetadataBindingModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public string Duration { get; set; }
        public int ReleaseYear { get; set; }
    }

    public class MetadataPostModel
    {
        public int movieId { get; set; }
        public string title { get; set; }
        public string language { get; set; }
        public string duration { get; set; }
        public int releaseYear { get; set; }
    }
}
