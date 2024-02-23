using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placer.Core.Entities
{
    internal class Payment
    {
        public int Id { get; set; }
        public int TouristId { get; set; }
        public Tourist Tourist { get; set; }
    }
}
