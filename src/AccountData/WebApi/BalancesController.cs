using System.Threading.Tasks;
using AccountData.Common.Domain.Services;
using AccountData.WebApi.Models.AccountData;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountData.WebApi
{
    [Authorize]
    [ApiController]
    [Route("api/balances")]
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
        [ProducesResponseType(typeof(BalancesModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync(string walletId)
        {
            if (string.IsNullOrWhiteSpace(walletId))
                return NotFound();

            var balances = await _balancesService.GetAllAsync(walletId);

            if (balances == null)
                return NotFound();

            var model = _mapper.Map<BalancesModel>(balances);

            return Ok(model);
        }

        [HttpGet("{walletId}/assets/{assetId}")]
        [ProducesResponseType(typeof(BalancesModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByAssetIdAsync(string walletId, string assetId)
        {
            if (string.IsNullOrWhiteSpace(walletId))
                return NotFound();

            var balances = await _balancesService.GetByAssetIdAsync(walletId, assetId);

            if (balances == null)
                return NotFound();

            var model = _mapper.Map<BalancesModel>(balances);

            return Ok(model);
        }
    }
}
