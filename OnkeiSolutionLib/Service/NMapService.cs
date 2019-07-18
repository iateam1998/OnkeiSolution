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
        string ScanPort(NMapWithPortOptionModel model);
        string BasicScan1Host(string host);
        string BasicScanMultiHost(List<string> hosts);
        string ScanPopularPort(NMapWithTopXportOptionModel model);
        string ScanOSFastExecution(string host);
        string DetectServiceDaemon(string host);
        string ScanTcpOrUdp(NMapTcpOrUdpOptionModel model);
        string DetectVulnerability(string host);

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

        public string BasicScan1Host(string host)
        {
            var argument = $" " + host;
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

        public string BasicScanMultiHost(List<string> hosts)
        {
            var argument = $" ";
            for(int i = 0; i < hosts.Count; i++)
            {
                if (i == hosts.Count - 1)
                {
                    argument += hosts[i] + ",";
                }
                else
                {
                    argument += hosts[i];
                }
            }
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

        public string ScanPort(NMapWithPortOptionModel model)
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
            argument += " " + model.Host;
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

        public string ScanPopularPort(NMapWithTopXportOptionModel model)
        {
            var argument = $"--top-ports " + model.TopXPort;
            argument += " " + model.Host;
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
        public string ScanOSFastExecution(string host)
        {
            var argument = $"-A -T4 " + host;
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
        public string DetectServiceDaemon(string host)
        {
            var argument = $"-sV " + host;
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
        public string ScanTcpOrUdp(NMapTcpOrUdpOptionModel model)
        {
            var argument = $"";
            if (model.Tcp)
            {
                argument += "-sT ";
            }
            if (model.Udp)
            {
                argument += "-sU ";
            }
            argument += " " + model.Host;
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
        public string DetectVulnerability(string host)
        {
            var argument = $"-Pn --script vuln " + host;
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
