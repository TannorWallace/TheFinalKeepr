<template>
  <div class="container-fluid mt-2">
    <div class="row Keep ">
      <div class="col-3 " v-for="Keep in Keep">
        <div class="card border border-dark m-1" style="width: 18rem;">
          <div class="card-body">
            <img :src="Keep.img" class="card-img-top" alt="...">
            <h5 class="card-title">{{Keep.name}}</h5>
            <p class="card-text">{{Keep.description}}
            </p>
            <!-- this button will be save -->
            <button class="btn btn-success">S</button>
            <!-- this button will be delete -->
            <button class="btn btn-danger" @click="deleteKeep">X</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'KeepsComponent',
    props: ['keepData'],
    data() {
      return {

      }
    },
    computed: {
      Keep() {
        return this.$store.state.Keep
      }
    },
    methods: {
      deleteKeep() {
        this.$store.dispatch('deleteKeep', this.keepId)
      }
    },
    components: {

    }
  }
</script>


<style scoped>

</style>