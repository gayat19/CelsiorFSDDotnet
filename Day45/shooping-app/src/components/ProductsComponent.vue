<script>
import { GetProducts } from '@/scripts/ProductService';
import ProductComponent from './ProductComponent.vue';

export default {
  name: 'ProductsCompoent',
  data() {
    return {
      products: []
    }
  },
  components: {
    ProductComponent
  },
  created() {
    GetProducts().then(response => {
      this.products = response.data;
      console.log(this.products);
    });
  }
}
</script>
<template>
  <div>
    <h1>Product</h1>
    <div v-for="product in products" :key="product.id">
      <ProductComponent :product="product" />
    </div>
  </div>
  </template>
  <style>

</style>