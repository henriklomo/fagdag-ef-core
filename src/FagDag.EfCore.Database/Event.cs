using System.ComponentModel.DataAnnotations.Schema;

namespace FagDag.EfCore.Database;

[Table("Events")]

public class Event
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Location? Location { get; set; }
    public string MusicType { get; set; }
}
