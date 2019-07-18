using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnkeiSolutionLib.Model.SqlMapModel
{
    public class SqlMapOptionModel
    {
        [Required]
        public string HostName { get; set; }
    }
}
