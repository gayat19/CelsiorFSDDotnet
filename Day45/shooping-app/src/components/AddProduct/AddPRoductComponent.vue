<script>
import { AddProduct } from '@/scripts/ProductService';

export default {
  name: 'AddProductComponent',
  data() {
    return {
        product:{
            "name": "",
            "description": "",
            "quantity": 0,
            "pricePerUnit": 0,
            "basicImage": ""
            },
      addProduct:()=>{
       
        event.preventDefault();
        const addProd = async()=>{
            var data = await AddProduct(this.product.name, this.product.description, this.product.quantity, this.product.pricePerUnit, this.product.basicImage)
            alert(data.message);
        }
        addProd();
        }
        
      }
    }
  }
</script>
<template>
    <div>
        <form>
            <div>
                <label class="form-control" for="name">Name</label>
                <input class="form-control" type="text" id="name" v-model="product.name">
            </div>
            <div>
                <label class="form-control" for="description">Description</label>
                <input class="form-control" type="text" id="description" v-model="product.description">
            </div>
            <div>
                <label class="form-control" for="quantity">Quantity</label>
                <input class="form-control" type="number" id="quantity" v-model="product.quantity">
            </div>
            <div>
                <label class="form-control" for="pricePerUnit">Price Per Unit</label>
                <input class="form-control" type="number" id="pricePerUnit" v-model="product.pricePerUnit">
            </div>
            <div>
                <label class="form-control" for="basicImage">Basic Image</label>
                <input class="form-control" type="text" id="basicImage" v-model="product.basicImage">
            </div>
            <button class="btn btn-success" @click="addProduct()" type="submit">Add Product</button>
        </form>
    </div>
</template>