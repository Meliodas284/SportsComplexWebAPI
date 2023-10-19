using System.Text.Json.Serialization;

namespace SportsComplexWebAPI.Models
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        
        [JsonIgnore]
        public List<Gym> Gyms { get; set; }
        
        [JsonIgnore]
        public List<Coach> Coaches { get; set; }
    }
}
