<template>
    <div class="main-nav">
        <nav class="navbar navbar-expand-md navbar-dark bg-cool">
            <button class="navbar-toggler" type="button" @click="toggleCollapsed">
                <span class="navbar-toggler-icon"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <router-link class="navbar-brand" to="/"><icon :icon="['fab', 'microsoft']"/> ASP.NET Core with Vue.js 2</router-link>

            <transition name="slide">
                <div :class="'collapse navbar-collapse' + (!collapsed ? ' show':'')" v-show="!collapsed">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item">
                            <router-link to="/" exact-active-class="active">
                                <icon icon="home" class="mr-2" /><span>Home</span> 
                            </router-link>
                        </li>
                        <li v-if="!isAuthenticated" class="nav-item">
                            <router-link to="/register" exact-active-class="active">
                                <icon icon="list" class="mr-2" /><span>Register</span> 
                            </router-link>
                        </li>
                        <li v-if="!isAuthenticated" class="nav-item">
                            <router-link to="/login" exact-active-class="active">
                                <icon icon="list" class="mr-2" /><span>Login</span> 
                            </router-link>
                        </li>
                        <li v-if="isAuthenticated" class="nav-item">
                            <a @click="logout" exact-active-class="active">
                                <icon icon="list" class="mr-2" /><span>Log out</span> 
                            </a>
                        </li>
                    </ul>
                </div>
            </transition>
        </nav>
    </div>
</template>

<script>
    import { routes } from '../router/routes'

    export default {
      data () {
        return {
          routes,
          collapsed: true
        }
      },
      methods: {
        toggleCollapsed: function (event) {
          this.collapsed = !this.collapsed
        },
        logout(){
            this.$store.dispatch('logout');
        }
      },
      computed:{
          isAuthenticated(){
              return this.$store.getters.isAuthenticated;
          }
      }
    }
</script>

<style scoped>
    .slide-enter-active, .slide-leave-active {
    transition: max-height .35s
    }
    .slide-enter, .slide-leave-to {
    max-height: 0px;
    }

    .slide-enter-to, .slide-leave {
    max-height: 20em;
    }
    .bg-cool{
        background-color: #003e82;
    }
</style>