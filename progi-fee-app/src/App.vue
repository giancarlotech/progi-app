<template>
  <div class="min-h-screen bg-gradient-to-br from-gray-100 to-blue-100 flex flex-col items-center py-10">
    <h1 class="text-3xl font-bold text-gray-800 mb-6">Progi Fee Calculator</h1>
    <FeeForm @result="handleCalculation " />
    <FeeResult :calculation-data="calculationResponse" />
  </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import FeeForm from "./components/FeeForm.vue";
import FeeResult from "./components/FeeResult.vue";

const calculationResponse = ref(null);

const handleCalculation  = (responseData: any) => {
  calculationResponse.value = responseData;
};
</script>
