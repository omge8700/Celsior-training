<template>
    <div class="form" >
        <label for="email">Email</label>
        <input id = "email" type=" email " v-model="email" />
        
        <label for ="password">Password</label>
        <input id = "password" type="password" v-model="password"/>
        
        <button :disabled="!email && !password" &click="login">Login</button>
    </div>
</template>

<script>
 export default {
    data: ()=> ({
        email: "",
        password : "", 
 }),
 methods: {
    login(){
        if(this.email && this.password){
            this.$router.push({ path : "/profile"});
        }


        },
    },
 };
</script >

<style scoped>
    form{
        padding: 10px;
    }
</style>
