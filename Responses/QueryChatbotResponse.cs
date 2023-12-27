using Newtonsoft.Json;

namespace KikuChatbotWrapper.Responses
{
    public class QueryChatbotResponse
    {
        [JsonProperty("role", NullValueHandling = NullValueHandling.Ignore)]
        public string role { get; set; }

        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string content { get; set; }
    }
}
