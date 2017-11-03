import Vue from 'vue'
import Router from 'vue-router'
import Material from 'vue-material'

import Login from '@/components/Login'
import Main from '@/components/Main'

Vue.use(Router)
Vue.use(Material)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Login',
      component: Login
    },
    {
      path: '/Main',
      name: 'Main',
      component: Main
    }
  ]
})
