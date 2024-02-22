using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placer.Core.Entities
{
    internal class Manager : AppUser
    {
        IEnumerable<Tour> Tours { get; set; }
    }
}
