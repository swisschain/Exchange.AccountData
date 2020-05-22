using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Services;
using AccountData.WebApi.Models.FeeTransfer;
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
    [Route("api/fee-transfer")]
    public class FeeTransferController : ControllerBase
    {
        private readonly IFeeTransferService _feeTransferService;
        private readonly IMapper _mapper;

        public FeeTransferController(IFeeTransferService feeTransferService, IMapper mapper)
        {
            _feeTransferService = feeTransferService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Paginated<FeeTransferModel, long>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionaryErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetManyAsync([FromQuery] FeeTransferRequestMany request)
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
            
            var domains = await _feeTransferService.GetAllAsync(brokerId, request.Id,
                request.FromAccountId, request.ToAccountId, request.FromWalletId, request.ToWalletId, request.OrderId, request.AssetId,
                sortOrder, request.Cursor, request.Limit);

            var result = _mapper.Map<List<FeeTransferModel>>(domains);

            return Ok(result.Paginate(request, Url, x => x.Id));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FeeTransferModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var brokerId = User.GetTenantId();
            
            var domain = await _feeTransferService.GetByIdAsync(brokerId, id);

            if (domain == null)
                return NotFound();

            var model = _mapper.Map<FeeTransferModel>(domain);

            return Ok(model);
        }
    }
}
