using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccs.Models
{
    public class Route_ : UpgradeableModel
    {
        [Required]
        [ForeignKey("Truck")]
        public int TruckId { get; set; }
        public Truck Truck { get; set; }

        public DateTime? StartedAt { get; }

        public DateTime? FinishedAt { get; }

        public DateTime? CancelledAt { get; }

        public ICollection<RouteDetail> Details { get; set; }

        public ICollection<Shipping> Shippings { get; set; }
    }

    public class RouteDetail : CreableModel
    {
        [Required]
        [ForeignKey("Route")]
        public int RouteId { get; set; }
        public Route_ Route { get; set; }

        [Required]
        public string Message { get; set; }
    }
}
