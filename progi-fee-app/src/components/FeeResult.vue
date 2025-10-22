<template>
  <div v-if="calculationData" class="bg-white shadow-lg rounded-2xl p-6 w-full max-w-md mx-auto mt-6">
    <h2 class="text-2xl font-bold mb-4 text-gray-800">Calculation Result</h2>

    <p class="text-gray-700 mb-2">
      <strong>Vehicle Price:</strong> ${{ calculationData.vehiclePrice }}
    </p>
    <p class="text-gray-700 mb-4">
      <strong>Vehicle Type:</strong> {{ calculationData.vehicleType === 1 ? "Common" : "Luxury" }}
    </p>

    <ul class="divide-y divide-gray-200 mb-4">
      <li v-for="fee in calculationData.fees" :key="fee.name" class="py-2 flex justify-between">
        <span>{{ fee.name }}</span>
        <span class="font-semibold">${{ fee.amount }}</span>
      </li>
    </ul>

    <p class="text-lg font-bold text-blue-700 text-right">
      Total: ${{ calculationData.total }}
    </p>
  </div>
</template>

<script setup lang="ts">
defineProps<{
  calculationData: {
    vehiclePrice: number;
    vehicleType: number;
    fees: { name: string; amount: number }[];
    total: number;
  } | null;
}>();
</script>
