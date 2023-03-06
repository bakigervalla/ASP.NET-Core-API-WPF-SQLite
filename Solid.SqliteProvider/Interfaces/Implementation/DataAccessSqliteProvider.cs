using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Solid.SqliteProvider.Constants;
using Solid.SqliteProvider.DomainModel;

namespace Solid.SqliteProvider.Interfaces.Implementation
{
    public class DataAccessSqliteProvider : IDataAccessProvider
    {
        private readonly SqliteContext _context;
        private readonly ILogger _logger;

        public DataAccessSqliteProvider(SqliteContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("DataAccessSqliteProvider");
        }

        public async Task<Package> SavePackage(Package package)
        {
            if (package.Id == 0)
                _context.Packages.Add(package);
            else
                _context.Packages.Update(package);

            await _context.SaveChangesAsync();
            return package;
        }

        public async Task<bool> DeletePackage(long Id)
        {
            var entity = _context.Packages.FirstOrDefault(p => p.Id == Id);
            if (entity == null) return false;
            _context.Packages.Remove(entity);
            var result = await _context.SaveChangesAsync();

            return result != 0;
        }

        public async Task<IEnumerable<Package>> GetPackagesByStatus(PackageStatus status)
        {
            return await _context.Packages
                .Where(p => p.Status == status)
                .ToListAsync();
        }

        public async Task<Package?> GetPackageById(long Id)
        {
            return await _context.Packages
                .FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<IEnumerable<Package>> GetPackagesByRecipient(long recipientId)
        {
            return await _context.Packages
                         .Where(p => p.RecipientId == recipientId)
                         .ToListAsync();

            //return await (from p in _context.Packages
            //              join r in _context.Recipients on p.RecipientId equals r.Id
            //              select p).ToListAsync();
        }


        public async Task<IEnumerable<Package>> GetPackages()
        {
            return await _context.Packages
                .ToListAsync();
        }

        public async Task<Recipient> SaveRecipient(Recipient recipient)
        {
            if (recipient.Id == 0)
                _context.Recipients.Add(recipient);
            else
                _context.Recipients.Update(recipient);

            await _context.SaveChangesAsync();
            return recipient;
        }

        public async Task<bool> DeleteRecipient(long Id)
        {
            var entity = _context.Recipients.FirstOrDefault(p => p.Id == Id);
            if (entity == null) return false;
            _context.Recipients.Remove(entity);
            var result = await _context.SaveChangesAsync();

            return result != 0;
        }

        public async Task<IEnumerable<Recipient>> GetRecipients()
        {
            return await _context.Recipients
                .ToListAsync();
        }

    }
}