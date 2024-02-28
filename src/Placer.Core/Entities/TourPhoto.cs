
namespace Placer.Core.Entities
{
    public class TourPhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string TouristId { get; set; }
        public int TourId { get; set; }
        public virtual Tourist Tourist { get; set; }
        public virtual Tour Tour { get; set; }
    }
}
