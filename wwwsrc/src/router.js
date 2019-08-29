import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import Vault from './views/Vault.vue'
// these are always red squiggles?
//@ts-ignore
import newVault from './Components/NewVaultComponent.vue'
//@ts-ignore

import newKeep from './Components/NewKeepComponent.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/newVault',
      name: 'newVault',
      component: newVault

    },
    {
      path: '/vault',
      name: 'Vault',
      component: Vault
    },
    {
      path: '/keeps',
      name: 'keeps',
      // component: Keeps
    },
    {
      path: '/newKeep',
      name: 'newKeep',
      component: newKeep

    },
    {
      path: "*",
      redirect: '/'
    }
  ]
})
