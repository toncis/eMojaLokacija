namespace eMojaLokacijaApi.Extensions.Hub
{
	public interface IMessageHubClient
	{
		Task SendLocationSearchInfoToUser(List<string> message);
	}
}
