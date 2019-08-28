<template>
  <div class="Vaults">
    <div class="card" style="width: 18rem;">
      <img src="..." class="card-img-top" alt="...">
      <div class="card-body">
        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's
          content.

        </p>
        <button class="btn btn-success">S</button>
        <!-- this button will be delete -->
        <button class="btn btn-danger" @click="deleteKeep">X</button>
      </div>
    </div>

  </div>
</template>


<script>
  export default {
    name: 'Vaults',
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