using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnkeiSolution.Model.ResponseModel;
using OnkeiSolutionLib.Model.SqlMapModel;
using OnkeiSolutionLib.Service;
using OnkeiSolutionLib.Util;

namespace OnkeiSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SqlMapController : ControllerBase
    {
        private ISqlMapService _sqlMapService;
        public SqlMapController(ISqlMapService sqlMapService)
        {
            _sqlMapService = sqlMapService;
        }
        [HttpGet("get-dbversion")]
        public IActionResult ScanPort([FromQuery]SqlMapOptionModel model)
        {
            string fileName = OnkeiUtil.GenerateTimeStamp();
            var result = _sqlMapService.GetDBVersion(model);
            if (result == null)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Model is not correct")
                    );
            }
            string link = "http://" + HttpContext.Request.Host.Value + "/file/download/" + OnkeiUtil.SaveFile(fileName, result);
            return Ok(BaseResponseModel.PrepareDataSuccess(result, "Success", link));
        }
    }
}