﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Placer.Core.Entities
{
    internal class Tourist : AppUser
    {
        IEnumerable<Tour> PastTours { get; set; }
        IEnumerable<Tour> BookedTours { get; set; }
        IEnumerable<Tour> LikedTours { get; set;  }
        IEnumerable<Tour> WishList {  get; set; }
        public int TourInId { get; set; }
        public virtual Tour Tour { get; set; }
    }
}