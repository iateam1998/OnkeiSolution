using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace OnkeiSolutionLib.Util
{
    public static class OnkeiUtil
    {
        public static string GenerateTimeStamp()
        {
            var time = DateTime.Now;
            var unixTime = ((DateTimeOffset)time).ToUnixTimeSeconds();
            return unixTime.ToString();
        }
        public static string ToHtml(string s, bool nofollow)
        {
            s = HttpUtility.HtmlEncode(s);
            string[] paragraphs = s.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);
            StringBuilder sb = new StringBuilder();
            foreach (string par in paragraphs)
            {
                sb.AppendLine("<p>");
                string p = par.Replace(Environment.NewLine, "<br />\r\n");
                if (nofollow)
                {
                    p = Regex.Replace(p, @"\[\[(.+)\]\[(.+)\]\]", "<a href=\"$2\" rel=\"nofollow\">$1</a>");
                    p = Regex.Replace(p, @"\[\[(.+)\]\]", "<a href=\"$1\" rel=\"nofollow\">$1</a>");
                }
                else
                {
                    p = Regex.Replace(p, @"\[\[(.+)\]\[(.+)\]\]", "<a href=\"$2\">$1</a>");
                    p = Regex.Replace(p, @"\[\[(.+)\]\]", "<a href=\"$1\">$1</a>");
                    sb.AppendLine(p);
                }
                sb.AppendLine("</p>");
            }
            return sb.ToString();
        }
        public static string CheckIpOrHost(string hostName)
        {
            //IPAddress iPAddress;
            //if (ip!= null && !IPAddress.TryParse(ip, out iPAddress))
            //{
            //    return null;
            //}
            if(Uri.CheckHostName(hostName) == UriHostNameType.Unknown)
            {
                return null;
            }
            return hostName;
        }
        public static string SaveFile(string fileName, string content)
        {
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "SaveFolder";
            fileName = "T" + fileName + ".txt";
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, fileName)))
            {
                outputFile.Write(content);
                return fileName;
            }
        }
        public static string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}
