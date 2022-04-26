using MovieTest.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTest.Models
{
    public class Metadata
    {
        public Metadata(MetadataBindingModel record)
        {
            this.Id = record.Id;
            this.MovieId = record.MovieId;
            this.Title = record.Title;
            this.Language = record.Language;
            this.Duration = TimeSpan.Parse(record.Duration);
            this.ReleaseYear = record.ReleaseYear;
        }

        public Metadata(MetadataPostModel model, int id)
        {
            this.Id = id;
            this.MovieId = model.movieId;
            this.Title = model.title;
            this.Language = model.language;
            this.Duration = TimeSpan.Parse(model.duration);
            this.ReleaseYear = model.releaseYear;
        }

        public int Id { get; set; }
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Language { get; set; }
        public TimeSpan Duration { get; set; }
        public int ReleaseYear { get; set; }

        internal bool IsValid()
        {
            if(string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Language) || ReleaseYear == 0 || Duration.Ticks == 0)
            {
                return false;
            }
            return true;
        }
    }
}
