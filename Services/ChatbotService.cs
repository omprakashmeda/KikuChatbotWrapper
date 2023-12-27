using KikuChatbotWrapper.Requests;
using KikuChatbotWrapper.Responses;
using KikuChatbotWrapper.RestApiHelper;

namespace KikuChatbotWrapper.Services
{
    public class ChatbotService
    {
        private readonly IRestClientHelper _restClientHelper;
        private readonly IConfiguration _configuration;

        string _baseUrl;

        public ChatbotService(IConfiguration configuration, IRestClientHelper restClientHelper)
        {
            _restClientHelper = restClientHelper;
            _configuration = configuration;

            _baseUrl = _configuration.GetValue<string>("KikuChatbot:BaseUrl");
        }

        public async Task<QueryChatbotResponse> QueryChatbot(QueryChatbotRequest request)
        {
            var url = new Uri($"{_baseUrl}/chatbot/query_chatbot/");

            var response = await _restClientHelper.PostAsync<QueryChatbotResponse, QueryChatbotRequest>(url, request);

            return response;
        }
        public async Task<CreateSessionResponse> CreateSession(CreateSessionRequest request)
        {
            CreateSessionResponse response = null;
            try
            {
                var url = new Uri($"{_baseUrl}/chatbot/create_session_for_user/");

                response = await _restClientHelper.PostAsync<CreateSessionResponse, CreateSessionRequest>(url, request);
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }
    }
}
