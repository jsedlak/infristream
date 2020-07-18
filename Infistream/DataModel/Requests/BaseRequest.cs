using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Infistream.DataModel.Requests
{
    public abstract class BaseRequest
    {
        protected BaseRequest(string requestType)
        {
            RequestType = requestType;
        }

        [JsonPropertyName("message-id")]
        public string MessageId { get; set; }

        [JsonPropertyName("request-type")]
        public string RequestType { get; set; }
    }
}
