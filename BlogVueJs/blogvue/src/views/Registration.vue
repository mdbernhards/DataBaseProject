<template>
  <div>
    <img alt="Vue logo" src="../assets/logo.png"> 
    <div>   
      <h1>Blog</h1>
      <h3>Register</h3>
    </div>
    <div class="container">
      <label for="firstname">Firstname: </label>
      <input type="text" placeholder="Enter your name" id="firstname" name="firstname"><br><br>

      <label for="surname">Surname: </label>
      <input type="text" placeholder="Enter your surname" id="surname" name="surname"><br><br>

      <label for="username">Username: </label>
      <input type="text" placeholder="Enter your username" id="username" name="username"><br><br>

      <label for="email">Email: </label>
      <input type="text" placeholder="Enter your email" id="email" name="email"><br><br>

      <label for="phonenr">Phone number: </label>
      <input type="text" placeholder="Enter your phone number" id="phonenr" name="phonenr"><br><br>

      <label for="password">Password: </label>
      <input type="password" placeholder="Enter your password" id="password" name="password"><br><br>

      <label for="repeatpass">Repeat Password: </label>
      <input type="password" placeholder="Repeat your password" id="repeatpass" name="repeatpass"><br><br>
            
      <input @click="register()" type="submit" value="Login" class="button">
    </div>
  </div>
</template>

<script>
  import axios from "axios";

  export default {
    name: 'Registration',
    data (){
      return{
        info: null,
        buttonPressed: false
      }
    },
    methods: {
      registerUser(){
        var config = {
          headers: { 'Access-Control-Allow-Origin': 'http://localhost:8080' }
        }; 

        axios
          .post('https://localhost:44310/register?name='+ document.getElementById("firstname").value + '&surname=' + document.getElementById("surname").value
                                                        + '&email=' + document.getElementById("email") + '&phoneNr=' + document.getElementById("phonenr")
                                                        + '&username=' + document.getElementById("username") + '&password=' + document.getElementById("password"), config)
          .then()
          .catch()
          .finally(() => this.loading = false);
      }
    }
  }
</script>