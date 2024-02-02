using Ecommerce.SOS.Application.Contrats.UserCases.Collections;
using Ecommerce.SOS.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.SOS.Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : ControllerBase
    {
        private readonly IGetPagedCollectionsUC _getPagedCollectionsUC;

        public CollectionsController(IGetPagedCollectionsUC getPagedCollectionsUC)
        {
            _getPagedCollectionsUC = getPagedCollectionsUC;
        }

        [HttpGet()]
        [Route("PagedCollections")]
        public async Task<IActionResult> PagedCollections([FromQuery]PagedCollectionsRequest request)
        {
            
            var result = await _getPagedCollectionsUC.GetPagedCollections(request);

            switch(result.Item1)
            {
                case Domain.Enums.StatusCode.Ok:
                    return Ok(result.Item2);
                case Domain.Enums.StatusCode.NoContent:
                    return NoContent();
                default:
                    return BadRequest();
            }
        }
    }
}
