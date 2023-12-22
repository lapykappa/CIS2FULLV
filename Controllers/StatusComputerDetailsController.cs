using DbFirstCIS2.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DbFirstCIS2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusComputerDetailsController : ControllerBase
    {
        private readonly IStatusComputerDetailsRepository _repository;

        public StatusComputerDetailsController(IStatusComputerDetailsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusComputerDetailsDto>>> GetAll()
        {
            var statusComputerDetails = await _repository.GetAllStatusComputerDetails();
            if (statusComputerDetails == null)
            {
                return NotFound();
            }

            return Ok(statusComputerDetails);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusComputerDetailsDto>> Get(int id)
        {
            var statusComputerDetails = await _repository.GetStatusComputerDetails(id);
            if (statusComputerDetails == null)
            {
                return NotFound();
            }

            return Ok(statusComputerDetails);
        }
    }
}



