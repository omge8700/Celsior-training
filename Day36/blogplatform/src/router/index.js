import Vue from "vue";
import Router from "vue-router";
import Profile from "@/components/Profile.vue";
import Login from "@/components/Login.vue";

Vue.use(Router);

const router=new Router ({
    mode: "history",

    routes : [
        {
            name : 'Profile',
            path: "/profile",
            component: Profile,
            meta :{
                needsAuth : true
            }
        },
        {
            name : "Login",
            path : "/login",
            component : Login

        }
    ]
});

router.beforeEach((to,from,next)=>{
    if (to.meta.needsAuth){
        next("/login");
    }else{
        next();
    }
});


    


export default router;
