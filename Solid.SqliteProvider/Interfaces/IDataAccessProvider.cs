using Solid.SqliteProvider.Constants;
using Solid.SqliteProvider.DomainModel;

namespace Solid.SqliteProvider.Interfaces
{
    public interface IDataAccessProvider
    {
        Task<Package> SavePackage(Package package);
        Task<bool> DeletePackage(long Id);
        Task<IEnumerable<Package>> GetPackages();
        Task<IEnumerable<Package>> GetPackagesByStatus(PackageStatus status);

        Task<Package> GetPackageById(long Id);

        Task<IEnumerable<Package>> GetPackagesByRecipient(long recipientId);

        Task<Recipient> SaveRecipient(Recipient recipient);
        Task<bool> DeleteRecipient(long id);
        Task<IEnumerable<Recipient>> GetRecipients();
    }
}
