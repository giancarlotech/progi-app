using Progi.Api.Pipeline;

namespace Progi.Api.Fees
{
    public class StorageFeeStep : IPipelineStep<FeeContext>
    {
        public void Process(FeeContext context)
        {
            const decimal fee = 100m;
            context.AddFee("Storage Fee", fee);
        }
    }
}
