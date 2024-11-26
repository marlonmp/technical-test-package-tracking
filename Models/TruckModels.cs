using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace ccs.Models
{
    [Index(nameof(Plate), IsUnique = true)]

    public class Truck : UpgradeableModel
    {
        [Required]
        [StringLength(7, MinimumLength=6)]
        public string Plate { get; set; }

        [Required]
        [Range(0, float.MaxValue)]
        public float CarryCapacity { get; set; }

        public ICollection<TruckMaintenance> Maintenances { get; set; }
    }

    public class TruckMaintenance : UpgradeableModel
    {
        [Required]
        [ForeignKey("Truck")]
        public int TruckId { get; set; }
        public Truck Truck { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string Message { get; set; }

        public bool IsActive { get; set; }

        public TruckMaintenance()
        {
            this.IsActive = true;
        }
    }
}
