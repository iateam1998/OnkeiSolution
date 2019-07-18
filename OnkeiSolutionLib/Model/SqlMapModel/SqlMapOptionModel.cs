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
    public class SqlMapWithDBOptionModel
    {
        [Required]
        public string HostName { get; set; }
        [Required]
        public string Database { get; set; }
    }
    public class SqlMapWithDBAndTableOptionModel
    {
        [Required]
        public string HostName { get; set; }
        [Required]
        public string Database { get; set; }
        [Required]
        public string TableName { get; set; }
    }
}
