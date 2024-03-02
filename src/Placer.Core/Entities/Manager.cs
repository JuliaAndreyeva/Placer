
using Microsoft.AspNetCore.Identity;

namespace Placer.Core.Entities
{
    public class Manager : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AgencyId { get; set; }
        public Agency Agency { get; set; }
        public virtual ICollection<Tour> Tours { get; set; }
    }
}
