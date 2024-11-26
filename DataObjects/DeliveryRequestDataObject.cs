using System.ComponentModel.DataAnnotations;
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

    public class DeliveryRequestProductCreateDTO
    {
        //public int DeliveryRequestId { get; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [Range(1, 100)]
        public int Amount { get; set; }

        [Required]
        public DevlieryRequestProductPriority Priority { get; set; }

        [Required]
        [Range(1, 1000)]
        public float Weight { get; set; }

        public DeliveryRequestProduct ToModel(DeliveryRequestProduct? deliveryRequestProduct = default)
        {
            if (deliveryRequestProduct != null)
            {
                deliveryRequestProduct.ProductId = this.ProductId;
                deliveryRequestProduct.Amount = this.Amount;
                deliveryRequestProduct.Priority = this.Priority;
                deliveryRequestProduct.Weight = this.Weight;

                return deliveryRequestProduct;
            }

            return new DeliveryRequestProduct
            {
                ProductId = this.ProductId,
                Amount = this.Amount,
                Priority = this.Priority,
                Weight = this.Weight
            };
        }
    }

    public class DeliveryRequestCreateDTO
    {
        [Required]
        public string Address { get; set; }

        public ICollection<DeliveryRequestProductCreateDTO> Products { get; set; }  = [];

        public DeliveryRequest ToModel()
        {
            return new DeliveryRequest
            {
                Address = this.Address,
                DeliveryRequestProducts = this.Products.Select(product => product.ToModel()).ToList(),
            };
        }

    }
}
