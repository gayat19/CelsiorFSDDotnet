<template>
  <img alt="Vue logo" src="./assets/logo.png">
  <!-- <HelloWorld msg="Welcome to Your Vue.js App"/>
  <ProductsComponent/>
  <LoginComponent/> 
  <hr/>
  <AddPRoductComponent/> -->
  <nav>
    <router-link to="/">Home</router-link> |
    <router-link to="/login">Login</router-link> |
    <router-link to="/products">Products</router-link> |
  </nav>
  <router-view/>
</template>

<script>


// import AddPRoductComponent from './components/AddProduct/AddPRoductComponent.vue';
// import HelloWorld from './components/HelloWorld.vue'
// import LoginComponent from './components/Login/LoginComponent.vue';
// import ProductsComponent from './components/ProductsComponent.vue';


export default {
  name: 'App',
  components: {
    // HelloWorld,
    // ProductsComponent,
    // // LoginComponent,
    // AddPRoductComponent
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
