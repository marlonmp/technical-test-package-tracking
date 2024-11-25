using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ccs.Models
{
    public class Route_ : BaseModel
    {
        [Required]
        [ForeignKey("Truck")]
        public int TruckId { get; set; }
        public Truck Truck { get; set; }

        public DateTime? StartedAt { get; set; }

        public DateTime? FinishedAt { get; set; }

        public DateTime? CancelledAt { get; set; }

        public ICollection<RouteDetail> Details { get; set; }

        public ICollection<Shipping> Shippings { get; set; }
    }

    public class RouteDetail
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Route")]
        public int RouteId { get; set; }
        public Route_ Route { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }

        public RouteDetail()
        {
            this.CreatedAt = DateTime.UtcNow;
        }
    }
}
