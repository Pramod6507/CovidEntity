namespace CovidEntity.Models
{
    public class AgeGroupCount
    {
        public int Id { get; set; }
        public int StartAge { get; set; }
        public int EndAge { get; set; }
        public int AgeCount { get; set; }
        public int CovidCountId { get; set; }
        public CovidCount CovidCount { get; set; }

    }
}
