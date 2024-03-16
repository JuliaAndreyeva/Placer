
namespace Placer.Core.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Image {  get; set; }
        public ICollection<TourPlaces> TourPlaces { get; set; }
    }
}
