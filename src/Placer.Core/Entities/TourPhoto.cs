
using System.Runtime.InteropServices.JavaScript;

namespace Placer.Core.Entities
{
    public class TourPhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime CreationTime { get; set; }
        public string TouristId { get; set; }
        public int TourId { get; set; }
        public Tourist Tourist { get; set; }
        public Tour Tour { get; set; }
    }
}
