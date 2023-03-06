using Microsoft.AspNetCore.Mvc;
using Solid.SqliteProvider.Constants;
using Solid.SqliteProvider.DomainModel;
using Solid.SqliteProvider.Interfaces;

namespace Solid.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PackageController : ControllerBase
    {

        private readonly IDataAccessProvider _repository;
        private readonly ILogger<PackageController> _logger;

        public PackageController(IDataAccessProvider repository, ILogger<PackageController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Package>> GetAllPackagesAsync()
        {
            return await _repository.GetPackages();
        }

        [HttpGet("delivered")]
        public async Task<IEnumerable<Package>> GetDeliveredPackages()
        {
            return await _repository.GetPackagesByStatus(PackageStatus.DELIVERED);
        }

        [HttpPost]
        public async Task<Package> AddPackage([FromBody] Package package)
        {
            return await _repository.SavePackage(package);
        }
        [HttpPut]
        public async Task<Package> EditPackage([FromBody] Package package)
        {
            return await _repository.SavePackage(package);
        }

        [HttpGet("{id:long}")]
        public async Task<Package> GetPackageById(long Id)
        {
            return await _repository.GetPackageById(Id);
        }

        [HttpGet("recipient/{recipientId:long}")]
        public async Task<IEnumerable<Package>> GetAllPackagesByRecipientAsync(long recipientId)
        {
            return await _repository.GetPackagesByRecipient(recipientId);
        }

        [HttpGet("barcode")]
        public async Task<IEnumerable<Package>> GetBarcode([FromQuery] long recipientId)
        {
            return await _repository.GetPackagesByRecipient(recipientId);
        }
      
    }
}