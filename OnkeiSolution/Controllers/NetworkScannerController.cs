using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnkeiSolution.Model.ResponseModel;
using OnkeiSolutionLib.Model.NMapModel;
using OnkeiSolutionLib.Service;
using OnkeiSolutionLib.Util;

namespace OnkeiSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworkScannerController : ControllerBase
    {
        private INMapService _nMapService;
        public NetworkScannerController(INMapService nMapService)
        {
            _nMapService = nMapService;
        }
        [HttpGet("scan-port")]
        public IActionResult ScanPort([FromQuery]ScanPortModel model)
        {
            string fileName = OnkeiUtil.GenerateTimeStamp();
            var check = OnkeiUtil.CheckIpOrHost(model.HostName);
            if (check == null)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Model is not correct")
                    );
            }
            if (model.PortTo != null && model.PortTo <= model.PortFrom)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Port is not correct")
                    );
            }
            var result = _nMapService.ScanPort(model);
            if (result == null)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Model is not correct")
                    );
            }
            string link = "http://" + HttpContext.Request.Host.Value + "/file/download/" + OnkeiUtil.SaveFile(fileName, result);
            return Ok(BaseResponseModel.PrepareDataSuccess(result,"Success",link));
        }
    }
}