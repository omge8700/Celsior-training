<template>
  <img alt="Vue logo" src="./assets/logo.png">
  <HelloWorld msg="Welcome to Your Vue.js App"/>
  <LoginComponent/>
  
  <ProdcutsComponent/>
  <AddProductComponent/>
  <app-header/>
  <Login/>
  <Profile/>
  <router-view/>
  <!--AddProductComponent/-->
  <hr>
</template>

<script>
//import AddProductComponent from './components/AddProduct/AddProductComponent.vue';
import AddProductComponent from './components/AddProduct/AddProductComponent.vue';
import HelloWorld from './components/HelloWorld.vue'
import Login from './components/Login.vue';
import LoginComponent from './components/Login/LoginComponent.vue';
import ProductsComponent from './components/ProductsComponent.vue';
import Profile from './components/Profile.vue';

export default {
  name: 'App',
  components: {
    HelloWorld,
    AddProductComponent,
    Login,
    Profile

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
