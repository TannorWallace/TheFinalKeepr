<template>
  <div class="container-fluid mt-2">
    <h2>public keeps</h2>
    <div class="row Keep" v-for=" Keep in Keep">
      <div class="col-3 ">
        <div class="card border border-dark m-1" style="width: 18rem;">
          <div class="card-body">
            <img :src="Keep.img" class="card-img-top" alt="...">
            <h5 class="card-title">{{Keep.name}}</h5>
            <p class="card-text">{{Keep.description}}
            </p>
            <p>Shares: {{Keep.shares}}</p>
            <p>Views: {{Keep.views}}</p>
            <p>Keeps: {{Keep.keeps}}</p>
            <!-- this button will be save -->
            <button class="btn btn-success" v-if="user.id">S</button>
            <!-- this button will view -->
            <button class="btn btn-success" @click="selectedKeep(Keep)" v-if="user.id">V</button>
            <!-- this button will be delete -->
            <button class="btn btn-danger" v-if="user.id" @click="deleteKeepbyId(Keep.id)">X</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  export default {
    name: 'KeepsComponent',
    // props: ['keepData'],
    data() {
      return {

      }
    },
    computed: {
      Keep() {
        return this.$store.state.Keep
      },
      user() {
        return this.$store.state.user;
      }
    },
    methods: {
      deleteKeepbyId(id) {
        // debugger
        this.$store.dispatch('deleteKeepById', id)
      },
      selectedKeep(Keep) {
        // debugger
        //WTF that took forever
        this.$router.push({ name: 'selectedKeep', params: { id: Keep.id } })
      }
    },
    components: {

    }
  }
</script>


<style scoped>

</style>