using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Services;
using AccountData.WebApi.Models.Order;
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
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Paginated<OrderModel, long>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionaryErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetManyAsync([FromQuery] OrderRequestMany request)
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

            var domains = await _orderService.GetAllAsync(
                brokerId, request.Id, request.ExternalId, request.WalletId, request.AssetPairId,
                request.OrderType, request.Side, request.Status, request.TimeInForce,
                sortOrder, request.Cursor, request.Limit);

            var result = _mapper.Map<List<OrderModel>>(domains);

            return Ok(result.Paginate(request, Url, x => x.Id));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OrderModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var brokerId = User.GetTenantId();

            var domain = await _orderService.GetByIdAsync(brokerId, id);

            if (domain == null)
                return NotFound();

            var model = _mapper.Map<OrderModel>(domain);

            return Ok(model);
        }
    }
}
