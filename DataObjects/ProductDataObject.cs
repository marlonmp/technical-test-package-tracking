using System.ComponentModel.DataAnnotations;
using ccs.Models;

namespace ccs.DataObjects
{
    public class ProductCreateUpdateDTO
    {
        [Required]
        [StringLength(48, MinimumLength = 3)]
        public string Name { get; set; }

        public Product ToModel(Product? product = default)
        {
            if (product != null)
            {
                product.Name = this.Name;
                return product;
            }

            return new Product { Name = this.Name };
        }
    }
}
