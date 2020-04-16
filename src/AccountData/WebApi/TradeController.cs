using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Services;
using AccountData.WebApi.Models.Trade;
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
    [Route("api/trade")]
    public class TradeController : ControllerBase
    {
        private readonly ITradeService _tradeService;
        private readonly IMapper _mapper;

        public TradeController(ITradeService tradeService, IMapper mapper)
        {
            _tradeService = tradeService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Paginated<TradeModel, string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionaryErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetManyAsync([FromQuery] TradeRequestMany request)
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

            var domains = await _tradeService.GetAllAsync(brokerId, request.ExternalId, request.WalletId,
                request.BaseAssetId, request.QuotingAssetId,
                sortOrder, request.Cursor, request.Limit);

            var result = _mapper.Map<List<TradeModel>>(domains);

            return Ok(result.Paginate(request, Url, x => x.ExternalId));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TradeModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var brokerId = User.GetTenantId();

            var domain = await _tradeService.GetByIdAsync(brokerId, id);

            if (domain == null)
                return NotFound();

            var model = _mapper.Map<TradeModel>(domain);

            return Ok(model);
        }
    }
}
