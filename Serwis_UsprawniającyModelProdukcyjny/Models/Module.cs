using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Serwis_UsprawniającyModelProdukcyjny.Models
{
    public class Module
    {
        [Key]
        public int id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double AssemblyTime { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public virtual SearchHistory SearchHistory { get; set; }
    }
}