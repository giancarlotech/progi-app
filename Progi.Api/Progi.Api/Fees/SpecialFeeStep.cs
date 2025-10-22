using Progi.Api.DTOs;
using Progi.Api.Pipeline;

namespace Progi.Api.Fees
{
    public class SpecialFeeStep : IPipelineStep<FeeContext>
    {
        public void Process(FeeContext context)
        {
            var rate = context.VehicleType == VehicleType .Common? 0.02m : 0.04m;
            var fee = context.VehiclePrice * rate;
            context.AddFee("Special Fee", fee);
        }
    }
}
