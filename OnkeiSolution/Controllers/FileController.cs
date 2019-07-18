using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnkeiSolutionLib.Util;

namespace OnkeiSolution.Controllers
{
    [ApiExplorerSettings(IgnoreApi =true)]
    public class FileController : Controller
    {
        //get /file/{fileName}
        [HttpGet]
        [Route("/file/download/{fileName}")]
        public async Task<IActionResult> Download(string fileName)
        {
            if (fileName == null)
                return Content("filename not present");
            var path = Path.Combine(
                           System.AppDomain.CurrentDomain.BaseDirectory,
                           "SaveFolder", fileName);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, OnkeiUtil.GetContentType(path), Path.GetFileName(path));
        }

    }
}