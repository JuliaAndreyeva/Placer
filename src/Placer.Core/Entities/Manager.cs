using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placer.Core.Entities
{
    public class Manager : AppUser
    {
        public int AgencyId { get; set; }
        public Agency Agency { get; set; }
        public ICollection<Tour> Tours { get; set; }
    }
}
