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
    public class MetadataController : ControllerBase
    {
        private List<Metadata> _metadata;
        private List<Metadata> database;
        public MetadataController()
        {
            var metadataList = new List<Metadata>();
            using (var reader = new StreamReader("metadata.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<MetadataBindingModel>().ToArray();
                foreach (var record in records)
                {
                    metadataList.Add(new Metadata(record));
                }
            }
            _metadata = metadataList;
            database = new List<Metadata>();
        }

        [HttpPost]
        public ActionResult PostMetadata(MetadataPostModel model)
        {
            try
            {
                var id = _metadata.Count();
                var metadata = new Metadata(model, id);
                database.Add(metadata);
                return Ok();
            } catch(Exception e)
            {
                return BadRequest(e.ToString());
            }            
        }

        [HttpGet("{movieId}")]
        public ActionResult Metadata(int movieId)
        {
            try
            {
                var metadata = _metadata.Where(e => e.MovieId == movieId);
                metadata = metadata.Where(e => e.IsValid()).OrderBy(e => e.Id);
                if (!metadata.Any())
                {
                    return NotFound();
                }
                var groupedMetadata = metadata.GroupBy(e => e.Language).ToArray();
                List<MetadataViewModel> viewModels = new List<MetadataViewModel>();
                foreach (var group in groupedMetadata)
                {
                    viewModels.Add(new MetadataViewModel(group.First()));
                }
                return Ok(viewModels);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }            
        }
    }
}
