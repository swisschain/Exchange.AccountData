using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AccountData.Common.Domain.Services;
using AccountData.WebApi.Models.Balance;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swisschain.Sdk.Server.Authorization;
using Swisschain.Sdk.Server.WebApi.Pagination;

namespace AccountData.WebApi
{
    [Authorize]
    [ApiController]
    [Route("api/balance")]
    public class BalancesController : ControllerBase
    {
        private readonly IBalancesService _balancesService;
        private readonly IMapper _mapper;

        public BalancesController(IBalancesService balancesService, IMapper mapper)
        {
            _balancesService = balancesService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BalancesModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync(BalanceRequestMany request)
        {
            if (request.AccountId == 0)
                return NotFound();

            var brokerId = User.GetTenantId();

            var sortOrder = request.Order == PaginationOrder.Asc
                ? ListSortDirection.Ascending
                : ListSortDirection.Descending;

            var balances = await _balancesService.GetAllAsync(brokerId, request.AccountId, request.WalletId, request.Asset,
                sortOrder, request.Cursor, request.Limit);

            if (balances == null)
                return NotFound();

            var model = _mapper.Map<BalancesModel>(balances);

            foreach (var balance in model.List)
                balance.Timestamp = model.Timestamp;

            return Ok(model);
        }

        [HttpGet("{accountId}/{walletId}/assets/{asset}")]
        [ProducesResponseType(typeof(BalancesModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByAssetAsync([Required] long accountId, long walletId, string asset)
        {
            if (accountId == 0)
                return NotFound();

            var brokerId = User.GetTenantId();

            var balances = await _balancesService.GetByAssetIdAsync(brokerId, accountId, walletId, asset);

            if (balances == null)
                return NotFound();

            var model = _mapper.Map<BalancesModel>(balances);

            model.List.Single().Timestamp = model.Timestamp;

            return Ok(model);
        }
    }
}
