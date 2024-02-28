
namespace Placer.Core.Entities
{
    public class Agency
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
    }
}
