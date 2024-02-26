using System.Collections;

namespace Placer.Core.Entities;

public class WishList
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int TouristId { get; set; }
    
    public ICollection<Tour> Tours { get; set; }
    public virtual Tourist Tourist { get; set; }
}