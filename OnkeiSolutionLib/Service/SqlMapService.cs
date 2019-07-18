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
        string GetUserAndRole(SqlMapOptionModel model);
        string GetCurrentUserDatabaseAndHostnameInformation(SqlMapOptionModel model);
        string ListInformationTables(SqlMapWithDBOptionModel model);
        string ListInformationColumnsOfTable(SqlMapWithDBAndTableOptionModel model);
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
        public string GetUserAndRole(SqlMapOptionModel model)
        {
            var argument = $"-u " + model.HostName + " –users –roles --batch";
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
        public string GetCurrentUserDatabaseAndHostnameInformation(SqlMapOptionModel model)
        {
            var argument = $"-u " + model.HostName + " –current-user –current-db –hostname --batch";
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
        public string ListInformationTables(SqlMapWithDBOptionModel model)
        {
            var argument = $"-u " + model.HostName + " -D "+model.Database+" --tables --batch";
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
        public string ListInformationColumnsOfTable(SqlMapWithDBAndTableOptionModel model)
        {
            var argument = $"-u " + model.HostName + " -D " + model.Database + " -T "+model.TableName+" --columns  --batch";
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
