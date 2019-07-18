using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnkeiSolutionLib.Model.NMapModel
{
    public class NMapWithPortOptionModel
    {
        [Required]
        public string Host { get; set; }
        [Required]
        [Range(1, 65535, ErrorMessage = "Port must be between 1 and 65535")]
        public int PortFrom { get; set; }
        [Range(1, 65535, ErrorMessage = "Port must be between 1 and 65535")]
        public int? PortTo { get; set; } = null;
    }
    public class NMapWithTopXportOptionModel
    {
        [Required]
        public string Host { get; set; }
        [Required]
        [Range(1, 1000,ErrorMessage = "TopXPort must be between 1 and 1000")]
        public int TopXPort { get; set; }
    }

    public class NMapTcpOrUdpOptionModel
    {
        [Required]
        public string Host { get; set; }
        public bool Tcp { get; set; } = true;
        public bool Udp { get; set; } = true;

    }
}
