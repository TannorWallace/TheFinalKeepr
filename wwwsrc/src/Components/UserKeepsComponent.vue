<template>
  <div class="container-fluid mt-2">
    <div class="row Keep ">
      <div class="col-3 " v-for="userKeep in userKeep">
        <div class="card border border-dark m-1" style="width: 18rem;">
          <div class="card-body">
            <img :src="userKeep.img" class="card-img-top" alt="...">
            <h5 class="card-title">{{userKeep.name}}</h5>
            <p class="card-text">{{userKeep.description}}
            </p>
            <!-- this button will be save -->
            <button class="btn btn-success" v-if="user.id">S</button>
            <!-- this button will be delete -->
            <button class="btn btn-danger" v-if="user.id" @click="deleteKeepbyId(userKeep.id)">X</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'UserKeepsComponent',
    // props: ['keepData'],
    data() {
      return {

      }
    },
    computed: {
      userKeep() {
        return this.$store.state.userKeeps
      },
      user() {
        return this.$store.state.user;
      }
    },
    methods: {
      deleteKeepbyId(id) {
        // debugger
        this.$store.dispatch('deleteKeepById', id)
      }
    },
    components: {

    }
  }
</script>


<style scoped>

</style>