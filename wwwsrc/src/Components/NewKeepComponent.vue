<template>
  <div class="newKeep">
    <div class="row">
      <router-link to='/'>Home</router-link>
      <!-- hey that bootswatch thing is pretty kewl -->
      <form @submit="makeNewKeep">
        <div class="form-group">
          <label class="col-form-label col-form-label-lg" for="keep"></label>
          <label class="col-form-label col-form-label-lg" for="keep">New Keep</label><br>
          <input class="form-control form-control-lg" type="text" placeholder="imageUrl Here" id="keep"
            v-model="newKeep.Img"><br>
          <input class="form-control form-control-lg" type="text" placeholder="Name" id="keep" v-model="newKeep.name">
          <label class="col-form-label col-form-label-lg" for="keep"></label>

          <input class="form-control form-control-lg" type="text" placeholder="Description" id="keep"
            v-model="newKeep.description">

          <!-- checkbox start here!!! -->
          <div class="form-check form-check-inline">
            <input class="form-check-input" type="checkbox" v-model="newKeep.isPrivate">Private</label>

            <!-- next checkbox is here!!! -->
            <!-- <div class="form-check form-check-inline">
              <input class="form-check-input" type="checkbox"  v-model="newKeep.isPrivate">Public</label> -->

            <button type="submit">Make Keep</button>
          </div>
        </div>
      </form>
    </div>


  </div>

</template>


<script>
  import router from '../router'
  export default {
    name: 'newKeep',
    data() {
      //ok remember the issues you had here! look at the new vault create component mah-bob
      return {
        newKeep: {
          name: "",
          img: "",
          description: ""
        }
      }
    },
    computed: {},
    methods: {
      makeNewKeep() {
        this.$store.dispatch('makeNewKeep', this.newKeep)
        // verify home is the correct place to push to(anxious emoji/barf emoji)
        router.push({ name: 'home' })
      },
      user() {
        return this.$store.state.user;
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>