using AutoMapper;
using Domain.Interface.Service;
using Domain.Model.Common;
using Domain.Model.Financial;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DinheirusAPI.Controllers.v1.Financial
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FinancialReleaseTypeController : ControllerBase
    {
        private readonly IFinancialReleaseTypeService _service;
        private readonly IMapper _mapper;
        public FinancialReleaseTypeController(IFinancialReleaseTypeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<FinancialReleaseTypeResponse>> GetFinancialReleases()
        {
            return await _service.Get();
        }

        [HttpGet("option-items")]
        [Authorize]
        public async Task<IEnumerable<OptionItemResponse>> GetUserProfilesToSelectOption()
        {
            return _mapper.Map<List<OptionItemResponse>>(await _service.Get());
        }
    }
}
