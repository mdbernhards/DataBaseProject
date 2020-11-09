<template>
    <div>
        <div>   
            <h1>Blog</h1>
            <h3>Register</h3>
        </div>
        <div>
            <label for="firstname">Firstname: </label>
            <input type="text" id="firstname" name="firstname"><br><br>

            <label for="surname">Surname: </label>
            <input type="text" id="surname" name="surname"><br><br>

            <label for="username">Username: </label>
            <input type="text" id="username" name="username"><br><br>

            <label for="email">Email: </label>
            <input type="text" id="email" name="email"><br><br>

            <label for="phonenr">Phone number: </label>
            <input type="text" id="phonenr" name="phonenr"><br><br>

            <label for="password">Password: </label>
            <input type="password" id="password" name="password"><br><br>

            <label for="repeatpass">Repeat Password: </label>
            <input type="password" id="repeatpass" name="repeatpass"><br><br>
            
            <input @click="register()" type="submit" value="Login">
            <h1>{{data}}</h1>
        </div>
    </div>
</template>

<script>
export default {
        name: 'Register',
        data (){
            return{
                data: null
            }
        },
        methods: {
            
            register(){

            }
        }
    }
</script>