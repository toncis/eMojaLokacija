using Microsoft.AspNetCore.SignalR;

namespace eMojaLokacijaApi.Extensions.Hub
{
	public class MessageHub : Hub<IMessageHubClient>
	{
		public async Task SendOffersToUser(List<string> message)
		{
			await Clients.All.SendLocationSearchInfoToUser(message);
		}
	}
}
