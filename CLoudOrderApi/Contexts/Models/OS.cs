using System.ComponentModel.DataAnnotations;

namespace CloudOrderApi.Contexts.Models
{
    public class OS
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Cloud> Clouds { get; set; } = new List<Cloud>();
    }
}
