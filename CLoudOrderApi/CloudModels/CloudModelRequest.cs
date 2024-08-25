using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Printing;

namespace CloudOrderApi.CloudModels
{
    public class CloudModelRequest
    {
        public int ClientId { get; set; }
        public string OS { get; set; }
        public int CoresNumber { get; set; }
        public int RamVolume { get; set; }
        public int HddVolume { get; set; }
        public string? Address { get; set; }
    }
}
