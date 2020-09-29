using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CovidEntity.Models.ViewModels
{
    public class AgeGroupViewModel
    {
        public int Id { get; set; }
        public int StartAge { get; set; }
        public int EndAge { get; set; }
        public int AgeCount { get; set; }
        public DateTime CovidCountId { get; set; }

    }
}