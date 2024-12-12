import Registration from "@/components/Login/Registration.vue";
//import Vue from "vue";
import LoginComponent from "@/components/Login/LoginComponent.vue";
import { createRouter } from "vue-router";
import { createWebHistory } from "vue-router";








const routes = [
        
        {
            name : "Login",
            path : "/login",
            component : LoginComponent

        },
        {
            name : "Registration",
            path : "/registration",
            component : Registration

        },

    ];

// router.beforeEach((to,from,next)=>{
//     if (to.meta.needsAuth){
//         if( isuserLoggedIn){
//             next();
//         }else{
//             next("/login");
//         }
        
//     }else{
//         next();
//     }
// });


    
const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes,
  });
   

export default router;
