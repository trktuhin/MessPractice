<template>
<div class="padding50">
<h2 v-if="isAuthenticated">Welcome Mr {{fullName}}</h2>
</div>
</template>

<script>
export default {
  data () {
    return {

    }
  },
  computed:{
      fullName(){
          return this.$store.getters.getFullName;
      },
      isAuthenticated(){
        return this.$store.getters.isAuthenticated;
      }
  },
  methods:{
    
  }
}
</script>

<style>
.padding50{
  padding: 50px;
}
</style>
