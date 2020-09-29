using System;

namespace CovidEntity.Models.ViewModels
{
    public class RegionalCountViewModel
    {
        public int Id { get; set; }
        public string Region { get; set; }
        public int RegionTotal { get; set; }
        public int RegionConfirmed { get; set; }
        public int RegionInpatientHospitalization { get; set; }
        public int RegionIcuHospitalization { get; set; }
        public int RegionRecovered { get; set; }
        public int RegionDeath { get; set; }
        public DateTime CovidCountId { get; set; }
    }
}