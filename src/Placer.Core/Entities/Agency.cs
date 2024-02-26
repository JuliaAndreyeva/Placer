using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
