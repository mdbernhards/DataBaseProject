<template>
    <div>
      <img alt="Vue logo" src="../assets/logo.png"> 
        <div>   
            <h1>Blog</h1>
            <h3>Login</h3>
        </div>
        <div class="container">
            <label for="username">Username: </label>
            <input type="text" placeholder="Enter Username" id="user" name="username"><br><br>

            <label for="password">Password: </label>
            <input type="password" placeholder="Enter Password" id="password" name="password"><br><br>

            <input @click="loginUser()" type="submit" value="Login" class="button">
            <div v-if="buttonPressed">
              {{hasData()}}
            </div>
        </div>
    </div>
</template>

<script>
  import axios from "axios";

  export default {
    name: 'Login',
    data (){
      return{
        info: null,
        buttonPressed: false
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
            this.info = response.data;
          })
          .catch(error => {
            console.log(error);
            this.errored = true;
          })
          .finally(() => this.loading = false);

          this.buttonPressed = true;
      },
      hasData(){
        if(this.info.username != null){
            this.$router.push('/Blog')
          }
      }
    }
  }
</script>





