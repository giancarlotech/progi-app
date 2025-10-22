<template>
  <div class="bg-white shadow-lg rounded-2xl p-6 w-full max-w-md mx-auto">
    <h2 class="text-2xl font-bold mb-4 text-gray-800">Fee Calculator</h2>

    <form @submit.prevent="onSubmit" class="space-y-4">
      <div>
        <label class="block text-sm font-semibold text-gray-700">Vehicle Price</label>
        <input
          v-model.number="form.vehiclePrice"
          type="number"
          class="mt-1 w-full border border-gray-300 rounded-lg p-2 focus:ring-2 focus:ring-blue-500"
          placeholder="Enter vehicle price"
          required
          min="1"
        />
      </div>

      <div>
        <label class="block text-sm font-semibold text-gray-700">Vehicle Type</label>
        <select
          v-model.number="form.vehicleType"
          class="mt-1 w-full border border-gray-300 rounded-lg p-2 focus:ring-2 focus:ring-blue-500"
        >
          <option :value="1">Common</option>
          <option :value="2">Luxury</option>
        </select>
      </div>

      <button
        type="submit"
        class="w-full bg-blue-600 text-white py-2 rounded-lg font-semibold hover:bg-blue-700 transition"
      >
        Calculate
      </button>
    </form>
  </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import { calculateFees } from "../services/feeService";
import { VehicleType } from "../enums/vehicleType";

const emit = defineEmits(["result"]);

const form = ref({
  vehiclePrice: 1000,
  vehicleType: VehicleType.Common,
});

const onSubmit = async () => {
  try {
    const data = await calculateFees(form.value);
    emit("result", data);
  } catch (error) {
    console.error("Error calculating fees:", error);
    alert("Error connecting to API");
  }
};
</script>
