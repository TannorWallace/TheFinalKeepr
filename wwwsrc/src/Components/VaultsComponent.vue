<template>
  <div class="container-fluid">
    <div class="">
      <h3> Welcom to Vaults-Tec {{user.username}}</h3>
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
            <Button @click="viewVault(Vault)">Vault</Button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  import router from '../router'
  export default {
    name: 'VaultsComponent',
    data() {
      return {}
    },
    mounted() {
      this.$store.dispatch('getVaultsByUserId')
    },

    computed: {
      user() {
        return this.$store.state.user;
      },
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
      },
      viewVault(Vault) {
        this.$router.push({ name: "vaultKeep", params: { VaultId: Vault.id } })
      }
    },

    components: {}
  }
</script>


<style scoped>

</style>