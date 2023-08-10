using Domain.Interface.Service;
using Domain.Model.Financial;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinheirusAPI.Controllers.v1.Financial
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FinancialDashboardController : ControllerBase
    {
        private readonly IFinancialReleaseService _service;
        public FinancialDashboardController(IFinancialReleaseService service)
        {
            _service = service;
        }
        [HttpGet]
        [Authorize]
        public async Task<FinancialDashboardResponse> GetFinancialReleases()
        {
            return await _service.GetDashBoardData();
        }
    }
}
