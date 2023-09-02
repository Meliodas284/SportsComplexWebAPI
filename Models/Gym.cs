namespace SportsComplexWebAPI.Models
{
    public class Gym
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Number { get; set; }
        public double Area { get; set; }
        public List<Section> Sections { get; set; } = new List<Section>();
        public List<Training> Trainings { get; set; } = new List<Training>();
    }
}
