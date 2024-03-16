
namespace Placer.Core.Entities
{
    public class Agency
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public ICollection<Tour> Tours { get; set; }
        public ICollection<Manager> Managers { get; set; }
    }
}
