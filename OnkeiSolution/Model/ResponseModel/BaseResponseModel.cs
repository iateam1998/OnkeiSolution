using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnkeiSolution.Model.ResponseModel
{
    public class BaseResponseModel
    {
        public BaseResponseModel()
        {

        }
        public BaseResponseModel(string output, bool success, string message, string link)
        {
            this.Output = output;
            this.Success = success;
            this.Message = message;
            this.Link = link;
        }
        [JsonProperty("output")]
        public string Output { get; set; }
        [JsonProperty("Success")]
        public bool Success { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; } = "";

        public static BaseResponseModel PrepareData(string output, bool success = false, string message = "", string link = "")
        {
            return new BaseResponseModel(output, success, message, link);
        }
        public static BaseResponseModel PrepareDataSuccess(string output, string message ="", string link ="")
        {
            return new BaseResponseModel(output, true, message, link);
        }
        public static BaseResponseModel PrepareDataFail(string message = "")
        {
            return new BaseResponseModel("", false, message, "");
        }
    }
}
