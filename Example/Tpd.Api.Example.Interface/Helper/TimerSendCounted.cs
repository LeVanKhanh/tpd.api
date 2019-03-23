using Tpd.Api.DataTransferObject;
using Tpd.Api.Interface.Hubs;
using Tpd.Api.Interface.Models.Dashboard;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tpd.Api.Interface.Helper
{
    public class TimerSendCounted : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly IHubContext<ChatHub> _hubContext;

        public TimerSendCounted(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        private async void DoWork(object state)
        {
            var random = new Random();

            var eastSafeArea = random.Next(30, 70);
            var eastProcessArea = random.Next(200, 300);

            var centerSafeArea = random.Next(950, 1200);
            var centerProcessArea = random.Next(100, 200);

            var westSafeArea = random.Next(30, 70);
            var westProcessArea = random.Next(200, 300);

            var dashBoardModel = new DashBoardResult
            {
                East = new AreaModel
                {
                    SafeArea = eastSafeArea,
                    ProcessArea = eastProcessArea
                },
                Center = new AreaModel
                {
                    SafeArea = centerSafeArea,
                    ProcessArea = centerProcessArea
                },
                West = new AreaModel
                {
                    SafeArea = westSafeArea,
                    ProcessArea = westProcessArea
                }
            };

            string signal = JsonConvert.SerializeObject(dashBoardModel);
            var model = new DtoDashboardMessage { Message = signal };

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", model.Message);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
