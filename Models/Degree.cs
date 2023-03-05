using System.Text.Json.Serialization;

namespace stankin1.Models;

public class Degree
{
    public int Id { get; set; }
    public string Name { get; set; }

    [JsonIgnore]
    public ICollection<Student> Students { get; set; }
}
