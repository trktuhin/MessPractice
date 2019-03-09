<template>
    <div id="login">
        <div class="login-form primary">
            <div class="input">
                <label for="userName">User Name</label>
                <input
                        type="text"
                        id="userName"
                        name="userName"
                        v-validate="'required'"
                        v-model="userName">
            </div>
            <div v-if="errors.has('userName')" class="error">User Name is required</div>
            <div class="input">
                <label for="password">Password</label>
                <input
                    type="password"
                    id="password"
                    v-model="password">
            </div>
            <div v-if="errors.has('userName')" class="error">User Name is required</div>
            <div class="submit">
                <button type="button" @click="login">Login</button>
            </div>
        </div>
    </div>
</template>
<script>
export default {
    data(){
        return{
            userName:null,
            password:null
        }
    },
    methods:{
        login(){
            this.$validator.validateAll().then((result) => {
                if (result) {
                    this.$store.dispatch('login',{UserName:this.userName,Password:this.password});
                }
            });
        }
    }
}
</script>
<style scoped>
.error{
    color:red;
}
.login-form {
    position: relative;
    width: 400px;
    top:120px;
    left:70%;
    margin-left: -400px;
    border: 1px solid #eee;
    padding: 20px;
    box-shadow: 0 2px 3px rgb(168, 167, 167);
  }

  .input {
    margin: 10px auto;
  }

  .input label {
    display: block;
    margin-bottom: 6px;
  }

  .input.inline label {
    display: inline;
  }

  .input input {
    font: inherit;
    width: 100%;
    padding: 6px 12px;
    box-sizing: border-box;
    border: 1px solid rgb(26, 223, 36);
  }

  .input.inline input {
    width: auto;
  }

  .input input:focus {
    outline: none;
    border: 1px solid #521751;
    background-color: #eee;
  }

  .input select {
    border: 1px solid #ccc;
    font: inherit;
  }

  .submit button {
    border: 1px solid #521751;
    color: #521751;
    padding: 10px 20px;
    font: inherit;
    cursor: pointer;
  }

  .submit button:hover,
  .submit button:active {
    background-color: #521751;
    color: white;
  }

  .submit button[disabled],
  .submit button[disabled]:hover,
  .submit button[disabled]:active {
    border: 1px solid #ccc;
    background-color: transparent;
    color: #ccc;
    cursor: not-allowed;
  }
</style>
