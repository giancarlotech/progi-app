using Progi.Api.Pipeline;

namespace Progi.Api.Fees
{
    public class AssociationFeeStep : IPipelineStep<FeeContext>
    {
        public void Process(FeeContext context)
        {
            decimal fee = context.VehiclePrice switch
            {
                <= 500 => 5,
                <= 1000 => 10,
                <= 3000 => 15,
                _ => 20
            };
            context.AddFee("Association Fee", fee);
        }
    }
}
