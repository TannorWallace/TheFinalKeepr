<template>
  <div class="Keep">
    <div class="card" style="width: 18rem;">
      <!-- <img src="..." class="card-img-top" alt="..."> -->
      <div class="card-body">
        <h5 class="card-title">Card title</h5>
        <p class="card-text">Lorem, ipsum dolor sit amet consectetur adipisicing elit. Perspiciatis alias unde nisi?
          Minus quas facere minima? Vel impedit velit debitis.
        </p>
        <a href="#" class="btn btn-primary">Go somewhere</a>
      </div>
    </div>

  </div>
</template>


<script>
  export default {
    name: 'Keep',
    data() {
      return {}
    },
    computed: {
      getAllKeeps() {
        return this.$store.state.keep
      }
    },
    methods: {},
    components: {
      // keeps
    }
  }
</script>


<style scoped>

</style>