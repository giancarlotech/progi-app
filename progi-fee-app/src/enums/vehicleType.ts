export enum VehicleType {
  Common = 1,
  Luxury = 2,
}

export const vehicleTypeNames: Record<VehicleType, string> = {
  [VehicleType.Common]: "Common",
  [VehicleType.Luxury]: "Luxury",
};