using KikuChatbotWrapper.Requests;
using KikuChatbotWrapper.Responses;
using KikuChatbotWrapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace KikuChatbotWrapper.Controllers
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase
    {
        private readonly ChatbotService _chatbotService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ChatbotService chatbotService)
        {
            _logger = logger;
            _chatbotService = chatbotService;
        }

        [HttpPost]
        [Route("query")]
        [ProducesResponseType(typeof(QueryChatbotResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Query([FromBody] QueryChatbotRequest request)
        {
            var response = await _chatbotService.QueryChatbot(request);
            return Ok(response);
        }

        [HttpPost]
        [Route("create_session")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CreateSessionErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSession([FromBody] CreateSessionRequest request)
        {
            var response = await _chatbotService.CreateSession(request);

            return response != null ? Ok(response) : BadRequest(new CreateSessionErrorResponse { error = "Session already exists" });
        }

        [HttpPost]
        [Route("delete_session")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CreateSessionErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteSession([FromBody] CreateSessionRequest request)
        {
            var response = await _chatbotService.DeleteSession(request);

            return response ? Ok( new { success =true, message = "Session deleted successfully" }) : BadRequest(new CreateSessionErrorResponse { error = "Session not found" });
        }
    }
}