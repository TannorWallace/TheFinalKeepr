<template>
  <div class="newVault">
    <div class="row">
      <router-link to='/'>Home</router-link>
      <!-- hey that bootswatch thing is pretty kewl -->
      <form @submit="makeNewVault">
        <div class="form-group">
          <label class="col-form-label col-form-label-lg" for="vault">New Vault</label>
          <input class="form-control form-control-lg" type="text" placeholder="Name" id="vault" v-model="newVault.name">
          <label class="col-form-label col-form-label-lg" for="vault"></label>
          <input class="form-control form-control-lg" type="text" placeholder="Description" id="vault"
            v-model="newVault.description">
          <button type="submit">Make Vault</button>
        </div>


      </form>
    </div>
  </div>


  </div>
</template>


<script>
  import router from '../router'
  export default {
    name: 'newVault',
    data() {
      return {
        // RRRRUUUGHGHGHGHGH!!!! SMH! SLEEPY TIME
        newVault: {
          name: "",
          description: ""
        }
      }
    },
    computed: {},
    // sweet baby jesus thank you for the capstone!!!
    methods: {
      //vue is NOT breaking on THIS name...
      makeNewVault() {
        this.$store.dispatch('makeNewVault', this.newVault)
        router.push({ name: 'vault' })
      },
      user() {
        return this.$store.state.user;
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>