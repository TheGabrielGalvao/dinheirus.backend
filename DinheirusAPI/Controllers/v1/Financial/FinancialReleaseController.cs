using Domain.Interface.Service;
using Domain.Model.Financial;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinheirusAPI.Controllers.v1.Financial
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FinancialReleaseController : ControllerBase
    {

        private readonly IFinancialReleaseService _service;
        public FinancialReleaseController(IFinancialReleaseService service)
        {
            _service = service;
        }
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<FinancialReleaseResponse>> GetFinancialReleases()
        {
            return await _service.Get();
        }

        [HttpGet("{uuid}")]
        [Authorize]
        public async Task<ActionResult<FinancialReleaseResponse>> GetFinancialReleases(Guid uuid)
        {
            return await _service.Get(uuid);
        }


        [HttpPost]
        public async Task<ActionResult<FinancialReleaseResponse>> PostFinancialRelease([FromBody] FinancialReleaseRequest transaction)
        {
            var newFinancialRelease = await _service.Create(transaction);
            return CreatedAtAction(nameof(GetFinancialReleases), new { uuid = newFinancialRelease.Uuid }, newFinancialRelease);
        }

        [HttpDelete("{uuid}")]
        public async Task<ActionResult> Delete(Guid uuid)
        {
            var transactionDelete = await _service.Get(uuid);
            if (transactionDelete == null)
                return NotFound();

            await _service.Delete(uuid);
            return NoContent();
        }

        [HttpPut("{uuid}")]
        public async Task<ActionResult> PutFinancialRelease(Guid uuid, [FromBody] FinancialReleaseRequest transaction)
        {
            if (uuid != transaction.Uuid)
                return BadRequest();

            await _service.Update(uuid, transaction);

            return NoContent();
        }
    }
}
