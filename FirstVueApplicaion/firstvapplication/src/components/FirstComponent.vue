<template>
    <h1>This is my first component - {{ custName }}</h1>
    <div v-html="divContent"></div>
    <hr/>
    <div>{{ divContent }}</div>
    <!-- <div v-bind:id="divId">THis is the id i will give dynamically for styling</div> -->
    <div :id="divId">THis is the id i will give dynamically for styling</div>
    <div>{{ myContent() }}</div>
    <div v-if="check">This could be shown</div>
    <ul>
        <li v-for="item in items" :key="item.id">{{ item.id }} -- {{ item.message }}</li>
    </ul>
</template>
<script>
    export default{
        name:'FirstComponent',
        data(){
            return{
                custName:"Ramu",
                divContent:'<p style="color:red">Hi</p>',
                divId:"div2",
                myContent:()=>{
                    return "Hello from function";
                },
                check:false,
                items:[{id:1,message:"Hello"},{id:2,message:"Hi"},{id:3,message:"Welcome"}]
 
            }
        }
    }
</script>
<style>
    h1{
        background-color: aquamarine;
    }
    #div1{
        background-color: blue;
    }
    #div2{
        background-color: pink;
    }
</style>
