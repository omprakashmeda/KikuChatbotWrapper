using Newtonsoft.Json;

namespace KikuChatbotWrapper.Responses
{
    public class CreateSessionErrorResponse
    {
        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public string error { get; set; }
    }
}
