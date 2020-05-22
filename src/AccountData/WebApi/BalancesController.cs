using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Services;
using AccountData.WebApi.Models.Balance;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swisschain.Sdk.Server.Authorization;
using Swisschain.Sdk.Server.WebApi.Common;
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
        [ProducesResponseType(typeof(Paginated<BalanceModel, long>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionaryErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllAsync([FromQuery] BalanceRequestMany request)
        {
            if (request.AccountId == 0)
                return NotFound();

            var brokerId = User.GetTenantId();

            var sortOrder = request.Order == PaginationOrder.Asc
                ? ListSortDirection.Ascending
                : ListSortDirection.Descending;

            var balances = await _balancesService.GetAllAsync(brokerId, request.AccountId, request.WalletId, request.Asset,
                sortOrder, request.Cursor, request.Limit);

            return Ok(balances.List.Paginate(request, Url, x => 0));
        }
    }
}
