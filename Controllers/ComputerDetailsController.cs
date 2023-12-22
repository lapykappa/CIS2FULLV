using DbFirstCIS2.DTO;
using DbFirstCIS2.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DbFirstCIS2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComputerDetailsController : ControllerBase
    {
        private readonly IComputerDetailsRepository _repository;

        public ComputerDetailsController(IComputerDetailsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComputerDetailsDto>> Get(int id)
        {
            var computerDetails = await _repository.GetComputerDetails(id);
            if (computerDetails == null)
            {
                return NotFound();
            }

            return computerDetails;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComputerDetailsDto>>> GetAll()
        {
            var computerDetails = await _repository.GetAllComputerDetails();
            if (computerDetails == null)
            {
                return NotFound();
            }

            return Ok(computerDetails);
        }



        [HttpPut("{computerId}/QlausTaskId/{newQlausTaskId}")]
        public async Task<IActionResult> UpdateQlausTaskId(int computerId, int newQlausTaskId)
        {
            try
            {
                await _repository.UpdateQlausTaskId(computerId, newQlausTaskId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{computerId}/Jobset/{newJobsetName}")]
        public async Task<IActionResult> UpdateJobset(int computerId, string newJobsetName)

        {
            try
            {
                await _repository.UpdateJobset(computerId, newJobsetName);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("RunPowerShellScript")]
        public IActionResult RunPowerShellScript()
        {
            var psScriptPath = @"C:\Users\Z004SRFB\Desktop\CIS2\Scripts\CIS_dummy.ps1";

            var startInfo = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                Arguments = $"/c start powershell.exe -NoExit -ExecutionPolicy Bypass -File {psScriptPath}",
                UseShellExecute = false,
                WorkingDirectory = Path.GetDirectoryName(psScriptPath)
            };

            var process = new Process() { StartInfo = startInfo };
            process.Start();

            return Ok();
        }



    }


}

