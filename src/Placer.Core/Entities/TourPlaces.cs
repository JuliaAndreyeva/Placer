
namespace Placer.Core.Entities
{
    public class TourPlaces
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public int PlaceId { get; set; }    
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; }
        public virtual Tour Tour { get; set; }  
        public virtual Place Place { get; set; }

    }
}
