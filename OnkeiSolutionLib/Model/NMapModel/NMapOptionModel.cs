using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnkeiSolutionLib.Model.NMapModel
{
    public class NMapOptionModel
    {
    }
    public class ScanPortModel
    {
        [Required]
        public string HostName { get; set; }
        [Required]
        [Range(1, 65535,ErrorMessage ="Port must be between 1 and 65535")]
        public int PortFrom { get; set; }
        [Range(1, 65535, ErrorMessage = "Port must be between 1 and 65535")]
        public int? PortTo { get; set; } = null;
    }
}
