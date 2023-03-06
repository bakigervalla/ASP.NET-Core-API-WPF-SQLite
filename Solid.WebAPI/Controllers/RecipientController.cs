using Microsoft.AspNetCore.Mvc;
using Solid.SqliteProvider.DomainModel;
using Solid.SqliteProvider.Interfaces;

namespace Solid.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipientController : ControllerBase
    {
        private readonly IDataAccessProvider _repository;
        private readonly ILogger<PackageController> _logger;

        public RecipientController(IDataAccessProvider repository, ILogger<PackageController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpPost]
        public async Task<Recipient> AddRecipient([FromBody] Recipient recipient)
        {
            return await _repository.SaveRecipient(recipient);
        }

        [HttpPut]
        public async Task<Recipient> EditRecipient([FromBody] Recipient recipient)
        {
            return await _repository.SaveRecipient(recipient);
        }
    }
}