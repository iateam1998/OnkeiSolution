using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace OnkeiSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerCmdController : ControllerBase
    {
        [HttpGet]
        [Route("cmd")]
        public IActionResult Get([FromQuery] string cmd)
        {
            var result = ExecuteCMD(cmd);
            return Ok(result);
        }

        [HttpGet]
        [Route("NmapCmd")]
        public IActionResult NmapCmd([FromQuery] string cmd)
        {
            var processStartInfo = new ProcessStartInfo()
            {
                Arguments = $"-h",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                FileName = "nmap",
                RedirectStandardOutput = true
            };

            using (Process process = Process.Start(processStartInfo))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    return Ok(result);
                }
            }

        }
        private string ExecuteCMD(string cmd)
        {
            string result = "";
            var processStartInfo = new ProcessStartInfo()
            {
                Arguments = $"-c {cmd}",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
                FileName = "/bin/bash",
                RedirectStandardOutput = true
            };

            using(Process process = Process.Start(processStartInfo))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    result = reader.ReadToEnd();
                    return result;
                }
            }
        }
    }
}