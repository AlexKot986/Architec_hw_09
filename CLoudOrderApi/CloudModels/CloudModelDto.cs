using CloudOrderApi.Contexts.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CloudOrderApi.CloudModels
{
    public class CloudModelResponse
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public OSDto OS { get; set; }
        public int CoresNumber { get; set; }
        public int RamVolume { get; set; }
        public int HddVolume { get; set; }
        public string? Address { get; set; }

    }
}
