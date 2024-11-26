using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccs.Models
{
    public enum DeliveryRequestStatus
    {
        CREATED,
        REJECTED,
        APPROVED
    }

    public class DeliveryRequest : UpgradeableModel
    {
        [Required]
        public string UserId { get; set; }
        public virtual AppUser User { get; set; } = null!;

        [Required]
        public string Address { get; set; }

        public DeliveryRequestStatus Status { get; set; }

        public ICollection<DeliveryRequestProduct> DeliveryRequestProducts { get; set; }

        public ICollection<Shipping> Shippings { get; set; }

        public DeliveryRequest()
        {
            this.Status = DeliveryRequestStatus.CREATED;
        }
    }

    public enum DevlieryRequestProductPriority
    {
        LOW,
        MEDIUM,
        HIGH,
    }

    public class DeliveryRequestProduct : CreableModel
    {
        [Required]
        public int DeliveryRequestId { get; set; }
        public virtual DeliveryRequest DeliveryRequest { get; set; }

        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        [Range(1, 100)]
        public int Amount { get; set; }

        [Required]
        public DevlieryRequestProductPriority Priority { get; set; }

        [Required]
        [Range(1, 1000)]
        public float Weight { get; set; }
    }
}
