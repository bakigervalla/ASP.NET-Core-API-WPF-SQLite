using Solid.UI.Constants;
using System;
using System.Collections.Generic;

namespace Solid.UI.Models
{
    public class Package
    {
        public Package() { this.Status = PackageStatus.RECEIVED; }

        public int Id { get; set; }
        public int RecipientId { get; set; }
        public string PackageIdentifier { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PackageStatus? Status { get; set; }
        public DateTime LastUpdated { get; set; }

        private ICollection<Recipient> Recipients { get; set; }
    }
}
