import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    Keep: [],
    activeKeep: {},
    Vault: [],
    activeVault: {},
    VaultKeep: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setKeeps(state, data) {
      state.Keep = data
    },
    setVaults(state, data) {
      state.Vault = data
    },
    setVaultKeeps(state, data) {
      state.VaultKeep = data
    },
    setActiveKeep(state, data) {
      state.activeKeep = data
    }

  },
  actions: {
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }

    },

    async createKeep({ dispatch, commit }, payload) {
      try {
        let res = await api.post('keep/', payload)
        dispatch('getKeeps')
      } catch (error) {
        console.error(error)
      }
    },

    async getKeeps({ dispatch, commit }) {
      try {
        let res = await api.get('keeps')
        commit('setKeeps', res.data)
      }
      catch (error) { console.log(error) }
    },

    async deleteKeepById({ dispatch, commit }, payload) {
      try {
        let res = await api.delete('keeps/' + payload)
        dispatch('getKeeps')
      } catch (error) {
        console.error(error)
      }
    },

    async createVault({ dispatch, commit }, payload) {

      try {
        let res = await api.post('vault', payload)
        dispatch('getVault')
      } catch (error) {
        console.error(error)
      }

    },
    async getVaultsByUserId({ dispatch, commit }) {
      try {

        let res = await api.get('vaults')
        commit('setVaults', res.data)
      }
      catch (error) { console.log(error) }
    },
    async getKeepsByUserId({ dispatch, commit }) {
      try {

        let res = await api.get('keeps')
        commit('setKeeps', res.data)
      }
      catch (error) { console.log(error) }
    },

    //UUUUUGHHHH THIS ONE BROKE MY BRAIIIIN (BARF EMOJI)
    async deleteVaultById({ dispatch, commit }, payload) {
      try {
        let res = await api.delete('vaults/' + payload)
        dispatch('getVaultsByUserId')
      } catch (error) {
        console.error(error)
      }
    },
    async makeNewVault({ dispatch, commit }, newVault) {
      try {
        let res = await api.post('/vaults', newVault)
        dispatch('getVaultsByUserId')
      }
      catch (error) { console.log(error) }
    },
    async makeNewKeep({ dispatch, commit }, newVault) {
      try {
        let res = await api.post('/keeps', newVault)
        dispatch('getKeepsByUserId')
      }
      catch (error) { console.log(error) }
    },

  }
})
