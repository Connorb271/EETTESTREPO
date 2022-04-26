using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using MovieTest.Models;
using MovieTest.Models.BindingModels;
using MovieTest.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private List<Stat> _stats;
        private List<Metadata> _metadata;
        public MovieController()
        {
            var statList = new List<Stat>();
            var metadataList = new List<Metadata>();
            using (var reader = new StreamReader("stats.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<StatBindingModel>().ToArray();
                foreach (var record in records)
                {
                    statList.Add(new Stat(record));
                }
            }
            using (var reader = new StreamReader("metadata.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<MetadataBindingModel>().ToArray();
                foreach (var record in records)
                {
                    metadataList.Add(new Metadata(record));
                }
            }
            _stats = statList;
            _metadata = metadataList;
        }

        [HttpGet("stats")]
        public ActionResult GetStats()
        {
            try
            {
                List<StatViewModel> statViewModels = new List<StatViewModel>();
                var movies = _metadata.OrderBy(e => e.Id).GroupBy(e => e.MovieId).ToArray();
                foreach(var movie in movies)
                {
                    var movieId = movie.Key;
                    var stats = _stats.Where(e => e.MovieId == movieId).ToArray();
                    statViewModels.Add(new StatViewModel() 
                    {
                        MovieId = movieId,
                        Title = movie.First().Title,
                        Watches = stats.Count(),
                        AverageWatchDurationS = (int)(stats.Average(e=>e.WatchDurationMs) / 1000),
                        ReleaseYear = movie.First().ReleaseYear
                    });
                }
                return Ok(statViewModels);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }            
        }
    }
}
