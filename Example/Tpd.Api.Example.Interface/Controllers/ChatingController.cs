using AutoMapper;
using Tpd.Api.DataTransferObject;
using Tpd.Api.Interface.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace Tpd.Api.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatingController : BaseController
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatingController(IMapper mapper, IHubContext<ChatHub> hubContext) :
            base(mapper)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<bool> SendMessage(string name, string message)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
            return true;
        }

        [HttpPost]
        [Route("ReciveMessage")]
        public async Task<bool> ReciveMessage(DtoDashboardMessage model)
        {
            if (model == null || string.IsNullOrEmpty(model.Message))
            {
                model = new DtoDashboardMessage { Message = DateTime.Now.ToLongTimeString() };
            }
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", model.Message);
            return true;
        }
    }
}
