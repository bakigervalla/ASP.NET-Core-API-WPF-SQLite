using Flurl.Http;
using Solid.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid.UI.API
{
   public interface IPackageService
    {
        Task<IFlurlResponse> GetAllPackagesAsync();
        Task<IFlurlResponse> GetDeliveredPackages();
        Task<IFlurlResponse> SavePackage(Package package);
        Task<IFlurlResponse> GetPackageById(long Id);
        Task<IFlurlResponse> GetAllPackagesByRecipientAsync(long recipientId);
        Task<IFlurlResponse> GetBarcode(long recipientId);

        Task<IFlurlResponse> SaveRecipient(Recipient recipient);
    }
}
