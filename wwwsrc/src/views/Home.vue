<template>
  <div class="row">
    <div class="home">
      <h1>Welcome Home {{user.username}}</h1>
      <button v-if="user.id" @click="logout">logout</button>
      <router-link v-else :to="{name: 'login'}">Login</router-link>
      <button @click="Vault">Vault</button>
      <KeepsComponent></KeepsComponent>

    </div>
  </div>
</template>

<script>
  import router from '../router'
  import KeepsComponent from '@/Components/KeepsComponent.vue'
  export default {
    name: "home",
    computed: {
      user() {
        return this.$store.state.user;
      }
    },
    methods: {
      logout() {
        this.$store.dispatch("logout");
      },
      Vault() {
        router.push({ name: 'Vault' })
      }
    },
    mounted() {
      this.$store.dispatch('getKeeps')
    },
    components: {
      KeepsComponent
    }
  };
</script>