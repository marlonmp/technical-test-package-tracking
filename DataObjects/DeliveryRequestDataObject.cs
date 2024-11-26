using ccs.Models;

namespace ccs.DataObjects
{
    public class DeliveryRequestListDTO
    {
        public int Id { get; set; }

        public virtual AppUser User { get; set; } = null!;

        public string Address { get; set; }

        public DeliveryRequestStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DeliveryRequestListDTO(DeliveryRequest deliveryRequest)
        {
            this.Id = deliveryRequest.Id;
            this.User = deliveryRequest.User;
            this.Address = deliveryRequest.Address;
            this.Status = deliveryRequest.Status;

            this.CreatedAt = deliveryRequest.CreatedAt;
            this.UpdatedAt = deliveryRequest.UpdatedAt;
        }
    }
}
