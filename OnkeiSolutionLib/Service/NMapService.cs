using OnkeiSolutionLib.Model.NMapModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace OnkeiSolutionLib.Service
{
    public interface INMapService
    {
        string ScanPort(ScanPortModel model);
    }
    public class NMapService : INMapService
    {
        private static ProcessStartInfo processStartInfo = new ProcessStartInfo()
        {
            Arguments = $"-h",
            CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden,
            UseShellExecute = false,
            FileName = "nmap",
            RedirectStandardOutput = true
        };
        public string ScanPort(ScanPortModel model)
        {
            var argument = $"-p " + model.PortFrom;
            if (model.PortTo != null)
            {
                if(model.PortTo <= model.PortFrom)
                {
                    return null;
                }
                argument += "-" + model.PortTo;
            }
            argument += " " + model.HostName;
            processStartInfo.Arguments = argument;
            using (Process process = Process.Start(processStartInfo))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }
    }
}
