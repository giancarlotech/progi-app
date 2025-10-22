using Progi.Api.Fees;

namespace Progi.Api.DTOs;
public record FeeResponse(
    decimal VehiclePrice,
    VehicleType VehicleType,
    IEnumerable<FeeResult> Fees,
    decimal Total
);
