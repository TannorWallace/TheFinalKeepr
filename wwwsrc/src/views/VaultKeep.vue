<template>
  <div class="VaultKeep">
    <p>{{activeVault.name}}</p>
    <div v-for="keep in getKeepsByVaultId">
      <p>{{keep.name}}</p>
    </div>

  </div>
</template>


<script>
  export default {
    name: 'VaultKeep',
    data() {
      return {}
    },
    mounted() {
      this.$store.dispatch('getKeepsByVaultId', this.$route.params.VaultId)
      this.$store.dispatch('getByVaultsId', this.$route.params.VaultId)
    },

    computed: {
      activeVault() {
        return this.$store.state.activeVault

      },
      getKeepsByVaultId() {
        return this.$store.state.VaultKeep

      }
    },
    methods: {},
    components: {}
  }
</script>


<style scoped>

</style>