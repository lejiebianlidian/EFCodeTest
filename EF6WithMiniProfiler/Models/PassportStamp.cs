using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EF6WithMiniProfiler.Models
{
    public class PassportStamp
    {
        public int StampId { get; set; }
        public DateTime Stamped { get; set; }

        public string StampingCountry { get; set; }

        [ForeignKey("passport")]//导航属性的名称 public Passport passport { get; set; }
        [Column(Order =1)]
        public int PassportNumber { get; set; }

        [ForeignKey("passport")]
        [Column(Order =2)]
        public string IssuingCountry { get; set; }

        public Passport passport { get; set; }





    }
}