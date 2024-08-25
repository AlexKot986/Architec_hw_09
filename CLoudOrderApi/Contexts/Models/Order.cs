using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CloudOrderApi.Contexts.Models
{
    public class Order
    {
        [Key] public int Id { get; set; }
        [ForeignKey("Client")] public int ClientId { get; set; }
        public bool IsPaid { get; set; }
       
        public virtual Client Client { get; set; }
        public virtual Cloud Cloud { get; set; }
    }
}
