using Solid.SqliteProvider.Constants;
using System.Text.Json.Serialization;

namespace Solid.SqliteProvider.DomainModel
{
    public class Package : BaseEntity
    {
        public Package() { this.Status = PackageStatus.RECEIVED; }

        public int RecipientId { get; set; }
        public string PackageIdentifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PackageStatus? Status { get; set; }
        public DateTime LastUpdated { get; set; }

        [JsonIgnore]
        private ICollection<Recipient> Recipients { get; set; }
    }
}
