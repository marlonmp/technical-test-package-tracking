using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ccs.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(24, MinimumLength=5)]
        public string DocumentNumber { get; set; }

        [Required]
        [StringLength(48, MinimumLength=3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(48, MinimumLength = 3)]
        public string LastName { get; set; }

        public bool IsActive { get; set; }

        public bool IsAdmin { get; set; }

        public ICollection<DeliveryRequest> DeliveryRequests { get; set; }

        public AppUser()
        {
            this.IsActive = true;
        }
    }
}
