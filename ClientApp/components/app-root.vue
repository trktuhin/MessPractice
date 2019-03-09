<template>
  <v-app id="app" class="container-fluid">
        <div class="row">
              <navbar></navbar>
              <v-content class="grey">
                <appSpinner v-if="isSpin"></appSpinner>
                <router-view></router-view>
              </v-content>
        </div>
    </v-app>
</template>

<script>
    import spinner from './spinner'
    import Nav from './Nav'

    export default {
      components: {
        appSpinner: spinner,
        'navbar':Nav
      },
      computed:{

        isSpin(){

          return this.$store.getters.isLoading;
        }
      },
      created(){
        this.$store.dispatch('tryLogin');
      }
    }
</script>

<style>
</style>
