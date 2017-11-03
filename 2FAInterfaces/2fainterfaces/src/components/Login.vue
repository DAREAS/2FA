<template>
  <div id="login">
    <form validate @submit.stop.prevent="submit">
      <md-input-container>
        <label>Username</label>
        <md-input v-model="userName"></md-input>
      </md-input-container>
      <md-input-container>
        <label>Password</label>
        <md-input type="password" v-model="password"></md-input>
      </md-input-container>
      <md-theme md-name="passButtons">
        <md-button class="md-raised md-accent text-button" @click="limpar">Limpar</md-button>
        <md-button class="md-raised md-primary text-button" @click="login">Entrar</md-button>
      </md-theme>
    </form>
  </div>
</template>

<script>
import Vue from 'vue'
import Material from 'vue-material'
import router from '../router'
import 'vue-material/dist/vue-material.css'

Vue.use(Material)

Vue.material.registerTheme('passButtons', {
  primary: {
    color: 'green',
    hue: 900
  },
  accent: {
    color: 'red',
    hue: 'A400'
  }
})

Vue.material.setCurrentTheme('passButtons')

export default {
  name: 'Login',
  data () {
    return {
      userName: '',
      password: '',
      errors: [],
      message: [],
      msg: 'Welcome to Your Vue.js App'
    }
  },
  methods: {
    login: function () {
      router.push({name: 'Main'})
    },
    limpar: function () {
      this.userName = ''
      this.password = ''
      this.message = null
      this.errors = null
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
#login {
  width: 25%;
  margin: auto;
  position: relative !important;
  align-self: center;
  align-items: center;
}

.text-button {
  font-size: 12;
  font-weight: bold
}
</style>
