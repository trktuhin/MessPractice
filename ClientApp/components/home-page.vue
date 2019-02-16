<template>
<div>
<h1>Expiration time:{{getExpireTime}}</h1>
</div>
</template>

<script>
export default {
  data () {
    return {

    }
  },
  computed:{
      getExpireTime(){
          return this.$store.getters.getExpirationTime;
      }
  }
}
</script>

<style>
</style>
