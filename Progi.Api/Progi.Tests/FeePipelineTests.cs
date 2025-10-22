using Progi.Api.DTOs;
using Progi.Api.Fees;
using Progi.Api.Pipeline;

namespace Progi.Tests
{
    public class FeePipelineTests
    {
        private readonly Pipeline<FeeContext> _pipeline;

        public FeePipelineTests()
        { 
            _pipeline = new Pipeline<FeeContext>(new IPipelineStep<FeeContext>[]
            {
                new BasicBuyerFeeStep(),
                new SpecialFeeStep(),
                new AssociationFeeStep(),
                new StorageFeeStep()
            });
        }

        [Theory]
        [InlineData(398, VehicleType.Common, 39.80, 7.96, 5.00, 100.00, 550.76)]
        [InlineData(501, VehicleType.Common, 50.00, 10.02, 10.00, 100.00, 671.02)]
        [InlineData(57, VehicleType.Common, 10.00, 1.14, 5.00, 100.00, 173.14)]
        [InlineData(1800, VehicleType.Luxury, 180.00, 72.00, 15.00, 100.00, 2167.00)]
        [InlineData(1100, VehicleType.Common, 50.00, 22.00, 15.00, 100.00, 1287.00)]
        [InlineData(1000000, VehicleType.Luxury, 200.00, 40000.00, 20.00, 100.00, 1040320.00)]
        public void Should_Calculate_Fees_Correctly(decimal price,
                                                    VehicleType type,
                                                    decimal expectedBasic,
                                                    decimal expectedSpecial,
                                                    decimal expectedAssociation, 
                                                    decimal expectedStorage,
                                                    decimal expectedTotal)
        {
            // Arrange
            var context = new FeeContext
            {
                VehiclePrice = price,
                VehicleType = type
            };

            // Act
            _pipeline.Execute(context);

            // Assert
            var basic = context.Fees.First(f => f.Name == "Basic Buyer Fee").Amount;
            var special = context.Fees.First(f => f.Name == "Special Fee").Amount;
            var association = context.Fees.First(f => f.Name == "Association Fee").Amount;
            var storage = context.Fees.First(f => f.Name == "Storage Fee").Amount;

            Assert.Equal(expectedBasic, basic);
            Assert.Equal(expectedSpecial, special);
            Assert.Equal(expectedAssociation, association);
            Assert.Equal(expectedStorage, storage);
            Assert.Equal(expectedTotal, context.Total);
        }
    }
}