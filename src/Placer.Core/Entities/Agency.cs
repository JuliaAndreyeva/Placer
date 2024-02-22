using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placer.Core.Entities
{
    internal class Agency
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        IEnumerable<Tour> Tours { get; set; }
    }
}
