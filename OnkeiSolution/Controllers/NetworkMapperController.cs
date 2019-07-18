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
    public class NetworkMapperController : ControllerBase
    {
        private INMapService _nMapService;
        public NetworkMapperController(INMapService nMapService)
        {
            _nMapService = nMapService;
        }

        /// <summary>
        /// Basic Nmap Scan against IP or host
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        [HttpGet("single-host")]
        public IActionResult BasicScan1Host([FromQuery]string host)
        {
            string fileName = OnkeiUtil.GenerateTimeStamp();
            var check = OnkeiUtil.CheckIpOrHost(host);
            if (check == null)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Model is not correct")
                    );
            }
            var result = _nMapService.BasicScan1Host(host);
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
        /// Scan multiple IP addresses
        /// </summary>
        /// <param name="hosts"></param>
        /// <returns></returns>
        [HttpGet("multi-host")]
        public IActionResult BasicScanMultiHost([FromQuery]List<string> hosts)
        {
            string fileName = OnkeiUtil.GenerateTimeStamp();
            var check = OnkeiUtil.CheckIpOrHost(hosts);
            if (check == null)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Model is not correct")
                    );
            }
            var result = _nMapService.BasicScanMultiHost(hosts);
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
        /// Scan specific ports or scan entire port ranges on a local or remote server
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("scan-port")]
        public IActionResult ScanPort([FromQuery]NMapWithPortOptionModel model)
        {
            string fileName = OnkeiUtil.GenerateTimeStamp();
            var check = OnkeiUtil.CheckIpOrHost(model.Host);
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
            string link = "";
            if (result.Trim() != "")
            {
                link = "http://" + HttpContext.Request.Host.Value + "/file/download/" + OnkeiUtil.SaveFile(fileName, result);
            }
            return Ok(BaseResponseModel.PrepareDataSuccess(result, "Success", link));
        }

        /// <summary>
        /// Scan the most popular ports
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("scan-popularport")]
        public IActionResult ScanPopularPort([FromQuery]NMapWithTopXportOptionModel model)
        {
            string fileName = OnkeiUtil.GenerateTimeStamp();
            var check = OnkeiUtil.CheckIpOrHost(model.Host);
            if (check == null)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Model is not correct")
                    );
            }
            var result = _nMapService.ScanPopularPort(model);
            if (result == null)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Model is not correct")
                    );
            }
            string link = "";
            if (result.Trim() != "")
            {
                link = "http://" + HttpContext.Request.Host.Value + "/file/download/" + OnkeiUtil.SaveFile(fileName, result);
            }
            return Ok(BaseResponseModel.PrepareDataSuccess(result, "Success", link));
        }

        /// <summary>
        /// Scan + OS and service detection with fast execution
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        [HttpGet("scan-os-fastexecution")]
        public IActionResult ScanOSFastExecution([FromQuery]string host)
        {
            string fileName = OnkeiUtil.GenerateTimeStamp();
            var check = OnkeiUtil.CheckIpOrHost(host);
            if (check == null)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Model is not correct")
                    );
            }
            var result = _nMapService.ScanOSFastExecution(host);
            if (result == null)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Model is not correct")
                    );
            }
            string link = "";
            if (result.Trim() != "")
            {
                link = "http://" + HttpContext.Request.Host.Value + "/file/download/" + OnkeiUtil.SaveFile(fileName, result);
            }
            return Ok(BaseResponseModel.PrepareDataSuccess(result, "Success", link));
        }

        /// <summary>
        /// Detect service/daemon versions
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        [HttpGet("detect-service-demon")]
        public IActionResult DetectServiceDaemon([FromQuery]string host)
        {
            string fileName = OnkeiUtil.GenerateTimeStamp();
            var check = OnkeiUtil.CheckIpOrHost(host);
            if (check == null)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Model is not correct")
                    );
            }
            var result = _nMapService.DetectServiceDaemon(host);
            if (result == null)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Model is not correct")
                    );
            }
            string link = "";
            if (result.Trim() != "")
            {
                link = "http://" + HttpContext.Request.Host.Value + "/file/download/" + OnkeiUtil.SaveFile(fileName, result);
            }
            return Ok(BaseResponseModel.PrepareDataSuccess(result, "Success", link));
        }

        /// <summary>
        /// Scan using TCP or UDP protocols
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet("scan-tcp-udp-protocol")]
        public IActionResult ScanTCPOrUDP([FromQuery]NMapTcpOrUdpOptionModel model)
        {
            string fileName = OnkeiUtil.GenerateTimeStamp();
            var check = OnkeiUtil.CheckIpOrHost(model.Host);
            if (check == null)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Model is not correct")
                    );
            }
            if (!model.Tcp && !model.Udp)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Model is not correct")
                    );
            }
            var result = _nMapService.ScanTcpOrUdp(model);
            if (result == null)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Model is not correct")
                    );
            }
            string link = "";
            if (result.Trim() != "")
            {
                link = "http://" + HttpContext.Request.Host.Value + "/file/download/" + OnkeiUtil.SaveFile(fileName, result);
            }
            return Ok(BaseResponseModel.PrepareDataSuccess(result, "Success", link));
        }

        /// <summary>
        /// Vulnerability detection using Nmap
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        [HttpGet("detect-vulnerability")]
        public IActionResult DetectVulnerability([FromQuery]string host)
        {
            string fileName = OnkeiUtil.GenerateTimeStamp();
            var check = OnkeiUtil.CheckIpOrHost(host);
            if (check == null)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Model is not correct")
                    );
            }
            var result = _nMapService.DetectVulnerability(host);
            if (result == null)
            {
                return BadRequest(
                    BaseResponseModel.PrepareDataFail("Model is not correct")
                    );
            }
            string link = "";
            if (result.Trim() != "")
            {
                link = "http://" + HttpContext.Request.Host.Value + "/file/download/" + OnkeiUtil.SaveFile(fileName, result);
            }
            return Ok(BaseResponseModel.PrepareDataSuccess(result, "Success", link));
        }
    }
}