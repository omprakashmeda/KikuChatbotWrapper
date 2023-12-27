using Newtonsoft.Json;

namespace KikuChatbotWrapper.Requests
{
    public class QueryChatbotRequest
    {
        [JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
        public string user_id { get; set; }

        [JsonProperty("session_id", NullValueHandling = NullValueHandling.Ignore)]
        public string session_id { get; set; }

        [JsonProperty("query", NullValueHandling = NullValueHandling.Ignore)]
        public string query { get; set; }

        [JsonProperty("access_levels", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> access_levels { get; set; }

        [JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
        public bool stream { get; set; }
    }
}
