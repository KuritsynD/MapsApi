using System.ComponentModel;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using Maps.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Maps;

public class Establishment : BaseModel
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string? Description { get; set; }
    public Guid CategoryId { get; set; }
    public Guid TagId { get; set; }
    public virtual Category Category { get; set; }
    public virtual Tag Tag { get; set; }
}