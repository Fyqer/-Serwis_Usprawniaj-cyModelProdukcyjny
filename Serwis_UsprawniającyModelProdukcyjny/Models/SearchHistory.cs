using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Serwis_UsprawniającyModelProdukcyjny.Models
{
    public class SearchHistory
    {
        [Key]
        public int id { get; set; }
        public int CityId { get; set; }
        public string ModuleName1 { get; set; }
        public string ModuleName2 { get; set; }
        public string ModuleName3 { get; set; }
        public string ModuleName4 { get; set; }
        public double PrductionCost { get; set; }

    }
}