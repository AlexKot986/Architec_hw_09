using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudOrderApi.Contexts.Models
{
    public class Cloud
    {
        [Key] public int Id { get; set; }
        [ForeignKey("Order")] public int OrederId { get; set; }
        [ForeignKey("OS")] public int OSId { get; set; }
        public int CoresNumber { get; set; }
        public int RamVolume { get; set; }
        public int HddVolume { get; set; }
        public string? Address { get; set; }

        public virtual Order Order { get; set; }
        public virtual OS OS { get; set; }
    }
}
