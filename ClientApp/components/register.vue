<template>
    <div id="register">
        <div class="register-form primary darken-3">
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
                <v-btn type="button" @click="register" class="primary darken-2 mx-auto">
                    Submit
                </v-btn>
                <!-- <div class="submit">
                    <button type="button" @click="register">Submit</button>
                </div> -->
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
    position: relative;
    width: 400px;
    top:30px;
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
    background-color: #eee;
  }

  .input.inline input {
    width: auto;
  }

  .input input:focus {
    outline: none;
    background-color: #eee;
  }

  .input select {
    border: 1px solid #ccc;
    font: inherit;
  }
</style>
