using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieTest.Models.ViewModels
{
    public class StatViewModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int Watches { get; set; }
        public int AverageWatchDurationS { get; set; }
        public int ReleaseYear { get; set; }
    }
}
