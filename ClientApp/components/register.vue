<template>
    <div id="register">
        <div class="register-form">
            <form @submit.prevent="onSubmit">
                <div class="input">
                    <label for="firstName">First Name</label>
                    <input
                        type="text"
                        id="firstName"
                        name="firstName"
                        v-validate="'required'"
                        v-model="firstName">
                </div>
                <div v-if="errors.has('firstName')" class="error">First Name is required</div>
                <div class="input">
                    <label for="lastName">Last Name</label>
                    <input
                        type="text"
                        id="lastName"
                        name="lastName"
                        v-validate="'required'"
                        v-model="lastName">
                </div>
                <div v-if="errors.has('lastName')" class="error">Last Name is required</div>
                <div class="input">
                    <label for="email">Email</label>
                    <input
                        type="email"
                        id="email"
                        name="email"
                        v-validate="'required|email'"
                        v-model="email">
                </div>
                <div v-if="errors.has('email')" class="error">Enter a valid Email address</div>
                <div class="input">
                    <label for="password">Password</label>
                    <input
                        type="password"
                        id="password"
                        v-model="password">
                </div>
                <div class="input">
                    <label for="confirmPassword">Confirm Password</label>
                    <input
                        type="password"
                        id="confirmPassword"
                        v-model="confirmPassword">
                </div>
                <div class="submit">
                    <button type="button" @click="register">Submit</button>
                </div>
            </form>
        </div>
    </div>
</template>
<script>
export default {
    data(){
        return {
            firstName:'',
            lastName:'',
            email:'',
            password:'',
            confirmPassword:''
        }
    },
    methods:{
        register(){
            this.$validator.validateAll().then((result) => {
                if (result) {
                    this.$store.dispatch('register',
                    {FirstName:this.firstName,
                    LastName:this.lastName,
                    Email:this.email,
                    Password:this.password});
                    
                }
            });
        }
    }
}
</script>
<style>
.error{
    color:red;
}
.register-form {
    width: 400px;
    margin: 30px auto;
    border: 1px solid #eee;
    padding: 20px;
    box-shadow: 0 2px 3px rgb(168, 167, 167);
  }

  .input {
    margin: 10px auto;
  }

  .input label {
    display: block;
    color: #4e4e4e;
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
    border: 1px solid #ccc;
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
