using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CovidEntity.Models
{
    [DisplayName("Covid19 case data")]
    public class CovidCount
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime Day { get; set; }
        [Required]
        [DisplayName("Total Number of  Cases")]
        public int TotalCases { get; set; }
        [Required]
        public int Confirmed { get; set; }
        [Required]
        public int Recovered { get; set; }
        [Required]
        public int Deaths { get; set; }
        public List<RegionalCount> RegionalCount { get; set; }
        public List<AgeGroupCount> AgeGroupCount { get; set; }
    }
}
