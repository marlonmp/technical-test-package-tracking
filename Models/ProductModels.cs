using System.ComponentModel.DataAnnotations;

namespace ccs.Models
{
    public class Product : UpgradeableModel
    {
        [Required]
        [StringLength(48, MinimumLength=3)]
        public string Name { get; set; }
    }
}
