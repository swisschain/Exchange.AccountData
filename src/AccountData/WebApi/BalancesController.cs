﻿using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AccountData.Common.Domain.Services;
using AccountData.WebApi.Models.Balance;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swisschain.Sdk.Server.Authorization;

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
        public async Task<IActionResult> GetAllAsync(long accountId, long walletId, string asset,
            ListSortDirection sortOrder = ListSortDirection.Ascending, long cursor = default, int limit = 50)
        {
            if (walletId == 0)
                return NotFound();

            var brokerId = User.GetTenantId();

            var balances = await _balancesService.GetAllAsync(brokerId, accountId, walletId, asset, sortOrder, cursor, limit);

            if (balances == null)
                return NotFound();

            var model = _mapper.Map<BalancesModel>(balances);

            foreach (var balance in model.List)
                balance.Timestamp = model.Timestamp;

            return Ok(model);
        }

        [HttpGet("{walletId}/assets/{asset}")]
        [ProducesResponseType(typeof(BalancesModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByAssetAsync(long accountId, long walletId, string asset)
        {
            if (walletId == 0)
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
