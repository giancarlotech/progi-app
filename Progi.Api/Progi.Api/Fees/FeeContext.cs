
using Progi.Api.DTOs;

namespace Progi.Api.Fees
{
    public class FeeContext
    {
        public decimal VehiclePrice { get; set; }
        public VehicleType VehicleType { get; set; }
        public List<FeeResult> Fees { get; } = new List<FeeResult>();
        public decimal Total => VehiclePrice + Fees.Sum(f => f.Amount);
        public void AddFee(string name, decimal amount)  => Fees.Add(new(name, amount));
    }
}
