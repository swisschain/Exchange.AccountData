﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Services;
using AccountData.WebApi.Models.OrderHistory;
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
    // commented out until we really need that controller
    //[ApiController]
    //[Route("api/order-history")]
    public class OrderHistoryController : ControllerBase
    {
        private readonly IOrderHistoryService _orderHistoryService;
        private readonly IMapper _mapper;

        public OrderHistoryController(IOrderHistoryService orderHistoryService, IMapper mapper)
        {
            _orderHistoryService = orderHistoryService;
            _mapper = mapper;
        }

        //[HttpGet]
        [ProducesResponseType(typeof(Paginated<OrderHistoryModel, long>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionaryErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetManyAsync([FromQuery] OrderHistoryRequestMany request)
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
            
            var domains = await _orderHistoryService.GetAllAsync(brokerId, request.Id, request.WalletId, request.AssetPairId, sortOrder, request.Cursor, request.Limit);

            var result = _mapper.Map<List<OrderHistoryModel>>(domains);

            return Ok(result.Paginate(request, Url, x => x.Id));
        }

        //[HttpGet("{id}")]
        [ProducesResponseType(typeof(OrderHistoryModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var brokerId = User.GetTenantId();
            
            var domain = await _orderHistoryService.GetByIdAsync(brokerId, id);

            if (domain == null)
                return NotFound();

            var model = _mapper.Map<OrderHistoryModel>(domain);

            return Ok(model);
        }
    }
}
