using Newtonsoft.Json;

namespace KikuChatbotWrapper.Requests
{
    public class CreateSessionRequest
    {
        [JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string user_id { get; set; }

        [JsonProperty("session_id", NullValueHandling = NullValueHandling.Ignore)]
        public string session_id { get; set; }
    }
}
