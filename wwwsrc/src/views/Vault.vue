<template>
  <div class="container-fluid">
    <button @click="newVault">Make New Vault</button>
    <VaultsComponent></VaultsComponent>
    <UserKeepsComponent></UserKeepsComponent>
    <!-- <div class="Vault">
      <div class="card" style="width: 18rem;">
        <img src="..." class="card-img-top" alt="...">
        <div class="card-body">
          <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's
            content.
          </p>
        </div>
      </div>

    </div> -->
  </div>
</template>


<script>
  import router from '../router'
  import UserKeepsComponent from '@/Components/UserKeepsComponent.vue'
  import VaultsComponent from '@/Components/VaultsComponent.vue'
  export default {
    name: 'Vault',
    data() {
      return {}
    },
    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    methods: {
      newVault() {
        router.push({ name: 'newVault' })
      }
    },
    mounted() {
      // debugger
      this.$store.dispatch('getVaultsByUserId', this.user.id)
      this.$store.dispatch('getUserKeeps', this.user.id)
    },

    components: {
      VaultsComponent,
      UserKeepsComponent
    }
  }
</script>


<style scoped>

</style>