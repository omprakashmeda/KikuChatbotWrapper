using Newtonsoft.Json;

namespace KikuChatbotWrapper.Responses
{
    public class DeleteSessionResponse
    {
        [JsonProperty("message", NullValueHandling = NullValueHandling.Ignore)]
        public string message { get; set; }
    }
}
