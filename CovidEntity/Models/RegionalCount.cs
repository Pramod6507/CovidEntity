namespace CovidEntity.Models
{
    public class RegionalCount
    {
        public int Id { get; set; }
        public string Region { get; set; }
        public int RegionTotal { get; set; }
        public int RegionConfirmed { get; set; }
        public int RegionInpatientHospitalization { get; set; }
        public int RegionIcuHospitalization { get; set; }
        public int RegionRecovered { get; set; }
        public int RegionDeath { get; set; }
        public int CovidCountId { get; set; }
        public CovidCount CovidCount { get; set; }
    }
}
