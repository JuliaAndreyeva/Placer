
namespace Placer.Core.Entities;
public class WishList
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string TouristId { get; set; }
    
    public ICollection<Tour> Tours { get; set; }
    public Tourist Tourist { get; set; }
}