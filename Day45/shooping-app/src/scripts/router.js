import HelloWorld from "@/components/HelloWorld.vue";
import LoginComponent from "@/components/Login/LoginComponent.vue";
import ProductsComponent from "@/components/ProductsComponent.vue";
import { createRouter,createWebHistory } from "vue-router";


const routes=[
    {path: '/', component: HelloWorld},
    {path: '/login', component: LoginComponent},
    {path: '/products', component: ProductsComponent}
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;