using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ccs.Models
{
    [Index(nameof(DocumentNumber), IsUnique=true)]
    [Index(nameof(Email), IsUnique=true)]
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

        public DateTime CreatedAt { get; }

        public DateTime UpdatedAt { get; }

        public ICollection<DeliveryRequest> DeliveryRequests { get; set; }

        public AppUser()
        {
            this.IsActive = true;
            this.CreatedAt = DateTime.UtcNow;
            this.UpdatedAt = DateTime.UtcNow;
        }
    }
}
