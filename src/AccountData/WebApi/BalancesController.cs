using System.Collections.Generic;
using System.Threading.Tasks;
using AccountData.Common.Domain.Services;
using AccountData.WebApi.Models.AccountData;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccountData.WebApi
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BalancesController : ControllerBase
    {
        private readonly IBalancesService _balancesService;
        private readonly IMapper _mapper;

        public BalancesController(IBalancesService balancesService, IMapper mapper)
        {
            _balancesService = balancesService;
            _mapper = mapper;
        }

        [HttpGet("{walletId}")]
        public async Task<IActionResult> GetAllAsync(string walletId)
        {
            var balances = await _balancesService.GetAllAsync(walletId);

            var model = _mapper.Map<List<BalanceModel>>(balances);

            return Ok(model);
        }

        [HttpGet("{walletId}/assets/{assetId}")]
        public async Task<IActionResult> GetByAssetIdAsync(string walletId, string assetId)
        {
            var balance = await _balancesService.GetByAssetIdAsync(walletId, assetId);

            var model = _mapper.Map<BalanceModel>(balance);

            return Ok(model);
        }
    }
}
