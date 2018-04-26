
using Microsoft.WindowsAzure.MobileServices;
using PrismDolbi.Helper;

namespace PrismDolbi.Abstractions
{
	public class AzureCloudService : ICloudService
	{
		MobileServiceClient client;

		public AzureCloudService()
		{
			client = new MobileServiceClient(Constants.ApplicationURL);
		}

		public ICloudTable<T> GetTable<T>() where T : TableData
		{
			return new AzureCloudTable<T>(client);
		}
	}
}
