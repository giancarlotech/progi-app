using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Progi.Api.DTOs;
using Progi.Api.Fees;
using Progi.Api.Pipeline;

namespace Progi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidController : ControllerBase
    {

        [HttpPost("calculate")]
        public IActionResult CalculateFees([FromBody] FeeRequest request)
        {  
            var context = new FeeContext
            {
                VehiclePrice = request.VehiclePrice,
                VehicleType = request.VehicleType
            };
             
            var pipeline = new Pipeline<FeeContext>()
                .AddStep(new BasicBuyerFeeStep())
                .AddStep(new SpecialFeeStep())
                .AddStep(new AssociationFeeStep())
                .AddStep(new StorageFeeStep());

            pipeline.Execute(context);

            var response = new FeeResponse(
                context.VehiclePrice,
                context.VehicleType,
                context.Fees,
                context.Total
            );

            return Ok(response);
        }
    }
}
