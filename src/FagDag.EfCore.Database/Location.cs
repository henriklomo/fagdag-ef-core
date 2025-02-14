
using System.ComponentModel.DataAnnotations.Schema;
namespace FagDag.EfCore.Database;

[Table("Location")]

public class Location
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public long Latitude { get; set; }
    public long Longitude { get; set; }
}

