using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using AccountData.Common.Domain.Services;
using AccountData.WebApi.Models.FeeInstruction;
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
    //[Route("api/fee-instruction")]
    public class FeeInstructionController : ControllerBase
    {
        private readonly IFeeInstructionService _feeInstructionService;
        private readonly IMapper _mapper;

        public FeeInstructionController(IFeeInstructionService feeInstructionService, IMapper mapper)
        {
            _feeInstructionService = feeInstructionService;
            _mapper = mapper;
        }

        //[HttpGet]
        [ProducesResponseType(typeof(Paginated<FeeInstructionModel, long>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ModelStateDictionaryErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetManyAsync([FromQuery] FeeInstructionRequestMany request)
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

            var domains = await _feeInstructionService.GetAllAsync(brokerId, request.Id, request.SourceWalletId, request.TargetWalletId, request.OrderId, request.AssetId, sortOrder, request.Cursor, request.Limit);

            var result = _mapper.Map<List<FeeInstructionModel>>(domains);

            return Ok(result.Paginate(request, Url, x => x.Id));
        }

        //[HttpGet("{accountId}")]
        [ProducesResponseType(typeof(FeeInstructionModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var brokerId = User.GetTenantId();

            var domain = await _feeInstructionService.GetByIdAsync(brokerId, id);

            if (domain == null)
                return NotFound();

            var model = _mapper.Map<FeeInstructionModel>(domain);

            return Ok(model);
        }
    }
}
