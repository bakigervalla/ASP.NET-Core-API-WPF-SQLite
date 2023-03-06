using Flurl.Http;
using Flurl.Http.Configuration;
using Solid.UI.Models;
using System.Threading.Tasks;

namespace Solid.UI.API.Implementation
{
    public class PackageService : IPackageService
    {

        private readonly IFlurlClient _flurlClient;
        private const string BaseUrl = "https://localhost:7054/";

        public PackageService(IFlurlClientFactory flurlClientFac)
        {
            _flurlClient = flurlClientFac.Get(BaseUrl);
        }

        public async Task<IFlurlResponse> GetAllPackagesAsync()
        {
            _flurlClient.BaseUrl= BaseUrl;
            return await _flurlClient.Request("package/")
               .GetJsonAsync();
        }

        // Add or Edit
        public async Task<IFlurlResponse> SavePackage(Package package)
        {
            return await _flurlClient.Request("package/")
           .PostJsonAsync(package);
        }

        public async Task<IFlurlResponse> GetPackageById(long Id)
        {
            return await _flurlClient.Request("package/" + Id)
                                     .GetJsonAsync();
        }

        public async Task<IFlurlResponse> GetAllPackagesByRecipientAsync(long recipientId)
        {
            return await _flurlClient.Request("package/recipient/" + recipientId)
                         .GetJsonAsync();
        }

        public async Task<IFlurlResponse> GetBarcode(long packageId)
        {
            return await _flurlClient.Request("barcode/" + packageId)
                         .GetJsonAsync();
        }

        // Add or Edit
        public async Task<IFlurlResponse> SaveRecipient(Recipient recipient)
        {
            return await _flurlClient.Request("package/recipient")
          .PostJsonAsync(recipient);
        }

        public async Task<IFlurlResponse> GetDeliveredPackages()
        {
            return await _flurlClient.Request("package/delivered")
            .GetJsonAsync();
        }
    }
}
