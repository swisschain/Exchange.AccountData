using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Services;
using AccountData.WebApi.Models.BalanceUpdate;
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
    [Route("api/balance-update")]
    public class BalanceUpdatesController : ControllerBase
    {
        private readonly IBalanceUpdateService _balanceUpdateService;
        private readonly IMapper _mapper;

        public BalanceUpdatesController(IBalanceUpdateService balanceUpdateService, IMapper mapper)
        {
            _balanceUpdateService = balanceUpdateService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Paginated<BalanceUpdateModel, long>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionaryErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetManyAsync([FromQuery] BalanceUpdateRequestMany request)
        {
            if (request.Limit > 1000)
            {
                ModelState.AddModelError($"{nameof(request.Limit)}", "Should not be more than 1000");

                return BadRequest(ModelState);
            }

            var sortOrder = request.Order == PaginationOrder.Asc
                ? ListSortDirection.Ascending
                : ListSortDirection.Descending;

            var brokerId = User.GetTenantId();

            var domains = await _balanceUpdateService.GetAllAsync(brokerId, request.Id, request.WalletId, request.AssetId, sortOrder, request.Cursor, request.Limit);

            var result = _mapper.Map<List<BalanceUpdateModel>>(domains);

            return Ok(result.Paginate(request, Url, x => x.Id));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BalanceUpdateModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var brokerId = User.GetTenantId();

            var domain = await _balanceUpdateService.GetByIdAsync(brokerId, id);

            if (domain == null)
                return NotFound();

            var model = _mapper.Map<BalanceUpdateModel>(domain);

            return Ok(model);
        }
    }
}
