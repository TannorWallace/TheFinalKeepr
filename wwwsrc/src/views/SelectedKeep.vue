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
            <button class="btn btn-success" @click="saveKeep(selectedKeep)">S</button>
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
      this.$store.dispatch("getKeepById", this.$route.params.)
      //NOTE gotta figure out the id above.
    },
    computed: {
      selectedKeep() {
        return this.$store.state.selectedKeep
      },
    },
    methods: {
      //just like drinkster!!
      saveKeep(selectedKeep) {
        this.$store.dispatch('saveKeepToVault', selectedKeep)
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>