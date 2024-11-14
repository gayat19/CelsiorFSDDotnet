<script>


export default {
  name: 'ProductCompoent',
  props: {

      product: {
        name: '',
        unitPrice: 0,
        quantity: 0,
        description: '',
        basicImage: ''

      }
    }
}
</script>
<template>
  <div>
    <h1>Product</h1>
    <div>{{ product.name }}</div>
  </div>
  </template>
  <style>

</style>