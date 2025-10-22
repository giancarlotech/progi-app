using Progi.Api.DTOs;
using Progi.Api.Pipeline;

namespace Progi.Api.Fees
{ 
    public class BasicBuyerFeeStep : IPipelineStep<FeeContext>
    {
        public void Process(FeeContext context)
        {
            var fee = context.VehiclePrice * 0.10m;
            fee = context.VehicleType == VehicleType.Common
                ? Math.Clamp(fee, 10m, 50m)
                : Math.Clamp(fee, 25m, 200m);

            context.AddFee("Basic Buyer Fee", fee);
        }
    }
}
