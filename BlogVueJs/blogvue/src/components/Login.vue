<template>
    <div>
        <div>   
            <h1>Blog</h1>
            <h3>Login</h3>
        </div>
        <form action="">
            <label for="fname">First name: </label>
            <input type="text" id="fname" name="fname"><br><br>
            <label for="lname">Last name: </label>
            <input type="text" id="lname" name="lname"><br><br>
            <input type="submit" value="Login">
        </form>     
    </div>
</template>

<script>
export default {
    name: 'Login'
}
</script>