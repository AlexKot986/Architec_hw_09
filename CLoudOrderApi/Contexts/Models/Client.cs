using System.ComponentModel.DataAnnotations;

namespace CloudOrderApi.Contexts.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public virtual List<Order> Orders { get; set; } = new List<Order>();
    }
}
