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

        /// <summary>
        /// List information about the existing databases 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("get-dbversion")]
        public IActionResult GetDBVersion([FromQuery]SqlMapOptionModel model)
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

        /// <summary>
        /// List information about Tables present in a particular Database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("list-tables")]
        public IActionResult ListInformationTables([FromQuery]SqlMapWithDBOptionModel model)
        {
            string fileName = OnkeiUtil.GenerateTimeStamp();
            var result = _sqlMapService.ListInformationTables(model);
            if (result == null)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Model is not correct")
                    );
            }
            string link = "http://" + HttpContext.Request.Host.Value + "/file/download/" + OnkeiUtil.SaveFile(fileName, result);
            return Ok(BaseResponseModel.PrepareDataSuccess(result, "Success", link));
        }

        /// <summary>
        /// List information about the columns of a particular table
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("list-columns-table")]
        public IActionResult ListInformationColumnsOfTable([FromQuery]SqlMapWithDBAndTableOptionModel model)
        {
            string fileName = OnkeiUtil.GenerateTimeStamp();
            var result = _sqlMapService.ListInformationColumnsOfTable(model);
            if (result == null)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Model is not correct")
                    );
            }
            string link = "http://" + HttpContext.Request.Host.Value + "/file/download/" + OnkeiUtil.SaveFile(fileName, result);
            return Ok(BaseResponseModel.PrepareDataSuccess(result, "Success", link));
        }

        /// <summary>
        /// Get user and role.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("user-role")]
        public IActionResult GetUserAndRole([FromQuery]SqlMapOptionModel model)
        {
            string fileName = OnkeiUtil.GenerateTimeStamp();
            var result = _sqlMapService.GetUserAndRole(model);
            if (result == null)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Model is not correct")
                    );
            }
            string link = "http://" + HttpContext.Request.Host.Value + "/file/download/" + OnkeiUtil.SaveFile(fileName, result);
            return Ok(BaseResponseModel.PrepareDataSuccess(result, "Success", link));
        }

        /// <summary>
        /// Get current user, current database and hostname information.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("current-user-role")]
        public IActionResult GetCurrentUserDatabaseAndHostnameInformation([FromQuery]SqlMapOptionModel model)
        {
            string fileName = OnkeiUtil.GenerateTimeStamp();
            var result = _sqlMapService.GetCurrentUserDatabaseAndHostnameInformation(model);
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