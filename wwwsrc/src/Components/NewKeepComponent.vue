<template>
  <div class="component">
    <div class="row">
      <!-- hey that bootswatch thing is pretty kewl -->
      <form @submit="makeNewKeep">
        <div class="form-group">
          <label class="col-form-label col-form-label-lg" for="keep">New Keep</label>
          <input class="form-control form-control-lg" type="text" placeholder="Name" id="keep" v-model="newKeep.name">
          <label class="col-form-label col-form-label-lg" for="keep"></label>
          <input class="form-control form-control-lg" type="text" placeholder="Description" id="keep"
            v-model="newKeep.description">
          <button type="submit">Make Vault</button>
        </div>


      </form>
    </div>
  </div>

  </div>
</template>


<script>
  export default {
    name: 'component',
    data() {
      return {}
    },
    computed: {},
    methods: {},
    components: {}
  }
</script>


<style scoped>

</style>