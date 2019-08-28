import Vue from 'vue'
// @ts-ignore
import App from './App.vue'
import router from './router'
import store from './store'
import AuthService from "./AuthService"

//Vue.config.productionTip = false
//REVIEW DO NOT TOUCHT THIS SECTION OF THE FILE AUTH IS DONE!!!
async function init() {
  let user = await AuthService.Authenticate()
  if (user) { store.commit("setUser", user) }
  new Vue({
    router,
    store,
    render: h => h(App)
  }).$mount('#app')
}
init()

