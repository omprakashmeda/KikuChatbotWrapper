using Newtonsoft.Json;

namespace KikuChatbotWrapper.Responses
{
    public class CreateSessionResponse
    {
        [JsonProperty("role", NullValueHandling = NullValueHandling.Ignore)]
        public string role { get; set; }

        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string message { get; set; }
    }
}
