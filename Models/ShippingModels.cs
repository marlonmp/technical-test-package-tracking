using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ccs.Models
{

    public class Shipping : BaseModel
    {
        [Required]
        public int RouteId { get; set; }
        public Route_ Route { get; set; } = null!;

        [Required]
        public int DeliveryRequestId { get; set; }
        public DeliveryRequest DeliveryRequest { get; set; } = null!;

        [StringLength(10, MinimumLength = 10)]
        public string Code { get; }

        public ICollection<ShippingDetail> Details { get; set; }

        public Shipping()
        {
            var id = this.Id.ToString("D4");
            var now = DateTime.UtcNow.ToString("ddMMYY");
            this.Code = $"{id}{now}";
        }
    }

    public class ShippingDetail
    {
        public int Id { get; set; }

        [Required]
        public int ShippingId { get; set; }
        public Shipping Shipping { get; set; } = null!;

        [Required]
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }

        public ShippingDetail()
        {
            this.CreatedAt = DateTime.UtcNow;
        }
    }
}
