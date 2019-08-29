<template>
  <div class="container-fluid">
    <button @click="newVault">Make New Vault</button>
    <VaultsComponent></VaultsComponent>
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
  import VaultsComponent from '@/Components/VaultsComponent.vue'
  export default {
    name: 'Vault',
    data() {
      return {}
    },
    computed: {},
    methods: {
      newVault() {
        router.push({ name: 'newVault' })
      }
    },
    mounted() {
      this.$store.dispatch('getVaultsByUserId')
    },

    components: {
      VaultsComponent

    }
  }
</script>


<style scoped>

</style>