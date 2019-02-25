<template>
    <div id="app" class="container-fluid">
        <div class="row">
            <div class="col-md-3">
                <nav-menu params="route: route"></nav-menu>
            </div>
            <div class="col-sm-9">
              <appSpinner v-if="isSpin"></appSpinner>
              <router-view></router-view>
            </div>
        </div>
    </div>
</template>

<script>

    import spinner from './spinner'
    import NavMenu from './nav-menu'

    export default {
      components: {
        'nav-menu': NavMenu,
        appSpinner: spinner
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
