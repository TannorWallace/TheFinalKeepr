<template>
  <div class="selectedKeep">
    <div class="row Keep">
      <div class="col-3 ">
        <div class="card border border-dark m-1" style="width: 18rem;">
          <div class="card-body">
            <img :src="selectedKeep.img" class="card-img-top" alt="...">
            <h5 class="card-title">{{selectedKeep.name}}</h5>
            <p class="card-text">{{selectedKeep.description}}
            </p>
            <div v-for="vault in Vaults">
              <button class="btn btn-success" @click="saveKeep(vault.id)">add to vault</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'selectedKeep',
    data() {
      return {
        //well that was a waste of time
      }
    },
    mounted() {
      //debugger
      //  >:( I wanna sleep but i gotta pass
      this.$store.dispatch("getKeepById", this.$route.params.id)
      //NOTE gotta figure out the id above.
      this.$store.dispatch("getVaultsByUserId")
    },
    computed: {
      selectedKeep() {
        return this.$store.state.selectedKeep
      },
      Vaults() {
        return this.$store.state.Vault
      }
    },
    methods: {
      //just like drinkster!!
      saveKeep(vaultId) {
        let vaultkeep = {
          vaultId: vaultId,
          keepId: this.$route.params.id
        }
        this.$store.dispatch('createVaultKeep', vaultkeep)
      },
      // saveKeepToVault()
    },
    components: {}
  }
</script>


<style scoped>

</style>