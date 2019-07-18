using OnkeiSolutionLib.Model.SqlMapModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace OnkeiSolutionLib.Service
{
    public interface ISqlMapService
    {
        string GetDBVersion(SqlMapOptionModel model);
    }
    public class SqlMapService : ISqlMapService
    {
        private static ProcessStartInfo processStartInfo = new ProcessStartInfo()
        {
            Arguments = $"-h",
            CreateNoWindow = true,
            WindowStyle = ProcessWindowStyle.Hidden,
            UseShellExecute = false,
            FileName = "sqlmap",
            RedirectStandardOutput = true
        };
        public string GetDBVersion(SqlMapOptionModel model)
        {
            var argument = $"-u " + model.HostName+ " -b --batch";
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
