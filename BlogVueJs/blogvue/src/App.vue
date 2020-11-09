<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png">
    <Login/>
  </div>
</template>

<script>
import Login from './components/Login'

export default {
  name: 'App',
  components: {
    Login
  }
}
</script>