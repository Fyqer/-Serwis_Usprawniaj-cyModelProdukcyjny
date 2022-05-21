using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Serwis_UsprawniającyModelProdukcyjny.Models
{
    public class City 
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }
        public double TransportCost{ get; set; }
        public double  CostOfWorkingPerHour{ get; set; }
        public virtual SearchHistory SearchHistory { get; set; }

    }
}