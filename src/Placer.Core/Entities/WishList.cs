
namespace Placer.Core.Entities;
public class WishList
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string TouristId { get; set; }
    
    public virtual ICollection<Tour> Tours { get; set; }
    public virtual Tourist Tourist { get; set; }
}