using MovieTest.Models.BindingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTest.Models
{
    public class Stat
    {
        public Stat(StatBindingModel record)
        {
            this.MovieId = record.movieId;
            this.WatchDurationMs = record.watchDurationMs;
        }

        public int MovieId { get; set; }
        public int WatchDurationMs { get; set; }
    }
}
