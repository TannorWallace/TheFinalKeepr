<template>
  <div class="newVault">
    <div class="row">
      <!-- hey that bootswatch thing is pretty kewl -->
      <form @submit="newVault">
        <div class="form-group">
          <label class="col-form-label col-form-label-lg" for="vault">New Vault</label>
          <input class="form-control form-control-lg" type="text" placeholder="Name" id="vault" v-model="newVault.Name">
          <label class="col-form-label col-form-label-lg" for="vault"></label>
          <input class="form-control form-control-lg" type="text" placeholder="Description" id="vault"
            v-model="newVault.Description">
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
      makeNewVault(e) {
        this.$store.dispatch('newVault', this.newVault)
        router.push({ name: 'vaults' })
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>