using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placer.Core.Entities
{
    internal class TourPhoto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int TouristId { get; set; }
        public virtual Tourist Tourist { get; set; }
    }
}
