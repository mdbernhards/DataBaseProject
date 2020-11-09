<template>
    <div>
        <div>   
            <h1>Blog</h1>
            <h3>Login</h3>
        </div>
            <label for="fname">Username: </label>
            <input type="text" id="user" name="fname"><br><br>
            <label for="lname">Password: </label>
            <input type="text" id="password" name="lname"><br><br>
            <input @click="loginUser()" type="submit" value="Login">
            <h1>{{data}}</h1>
    </div>
</template>

<script>
    import axios from "axios";

    export default {
        name: 'Login',
        data (){
            return{
                data: null
            }
        },
        methods: {
            
            loginUser(){
                
                var config = {
                headers: { 'Access-Control-Allow-Origin': 'http://localhost:8080' }
                }; 

                axios
                    .get('https://localhost:44310/login?username='+ document.getElementById("user").value + '&password=' + document.getElementById("password").value, config)
                    .then(response => {
                        this.data = response;
                    })
                    .catch(error => {
                        console.log(error);
                        this.errored = true;
                    })
                    .finally(() => this.loading = false);

                if(this.loading == false){
                    window.location.href = 'http://localhost:8080/Register';
                }
            }
        }
    }
</script>