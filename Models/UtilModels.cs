using System.ComponentModel.DataAnnotations;

namespace ccs.Models
{
    public abstract class CreableModel
    {
        public int Id { get; set; }

        [Timestamp]
        public DateTime CreatedAt { get; private set; }

        public void AddTimestamp()
        {
            this.CreatedAt = DateTime.UtcNow;
        }
    }

    public abstract class UpgradeableModel : CreableModel
    {
        [Timestamp]
        public DateTime UpdatedAt { get; private set; }

        public void AddTimestamp()
        {
            base.AddTimestamp();
            this.UpdateTimestamp();
        }

        public void UpdateTimestamp()
        {
            this.UpdatedAt = DateTime.UtcNow;
        }
    }
}
