using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChimesPortal.Models
{
    public class Crane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Category { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }

        public decimal? BoomLength { get; set; }
        public decimal? JibLength { get; set; }
        public int? NumberOfAxles { get; set; }
    }
}