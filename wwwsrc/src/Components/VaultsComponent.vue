<template>
  <div class="container-fluid">



    <div class="">
      <h3>Vaults-Tec</h3>
      <router-link to='/'>Home</router-link>
    </div>
    <div class="row">
      <div class="Vaults" v-for="Vault in Vault">
        <div class="card" style="width: 18rem;">
          <div class="card-body">
            <h4>{{Vault.name}}</h4>
            <p class="card-text">
              {{Vault.description}}
            </p>
            <button class="btn btn-success">S</button>
            <!-- this button will be delete -->
            <button class="btn btn-danger" @click="deleteVaultById(Vault.id)">X</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'VaultsComponent',
    data() {
      return {}
    },
    computed: {
      Vault() {
        return this.$store.state.Vault
      }
    },
    methods: {
      Home() {
        router.push({ name: 'Home' })
      },
      deleteVaultById(id) {

        this.$store.dispatch("deleteVaultById", id)
      }
    },

    components: {}
  }
</script>


<style scoped>

</style>