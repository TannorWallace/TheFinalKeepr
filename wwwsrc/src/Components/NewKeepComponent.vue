<template>
  <div class="newKeep">
    <div class="row">
      <!-- hey that bootswatch thing is pretty kewl -->
      <form @submit="makeNewKeep">
        <div class="form-group">
          <label class="col-form-label col-form-label-lg" for="keep"></label>
          <input class="form-control form-control-lg" type="text" placeholder="imageUrl Here" id="keep"
            v-model="newKeep.Img">
          <label class="col-form-label col-form-label-lg" for="keep">New Keep</label>
          <input class="form-control form-control-lg" type="text" placeholder="Name" id="keep" v-model="newKeep.name">
          <label class="col-form-label col-form-label-lg" for="keep"></label>
          <input class="form-control form-control-lg" type="text" placeholder="Description" id="keep"
            v-model="newKeep.description">
          <button type="submit">Make Keep</button>
        </div>


      </form>
    </div>
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
      }
    },
    components: {}
  }
</script>


<style scoped>

</style>