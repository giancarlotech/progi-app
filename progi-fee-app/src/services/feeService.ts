import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7281/api",
});

export interface FeeRequest {
  vehiclePrice: number;
  vehicleType: number; // 1=Common, 2=Luxury
}

export const calculateFees = async (request: FeeRequest) => {
  const response = await api.post("/Bid/calculate", request);
  return response.data;
};