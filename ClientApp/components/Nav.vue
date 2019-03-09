<template>
    <nav class="top30">
        <v-toolbar app>
            <v-snackbar v-model="snackbar" timeout="8000" top color="success">
                <span>Awesome! You added a new project..</span>
                <v-icon flat color="white" @click="snackbar=false" right>close</v-icon>
            </v-snackbar>
            <v-toolbar-side-icon class="grey--text" @click="drawer=!drawer"></v-toolbar-side-icon>
            <v-toolbar-title class="text-uppercase grey--text">
                <span class="headline font-weight-light">Smart</span>
                <span class="headline font-weight-bold ">Mess</span>
            </v-toolbar-title>
            <v-spacer></v-spacer>
            <v-menu offset-y>
                <v-btn flat slot="activator">
                    <v-icon left>expand_more</v-icon>
                    <span>Menu</span>
                </v-btn>
                <v-list>
                    <v-list-tile v-for="link in links" :key="link.text" :to="link.route">
                        <v-list-tile-title>{{link.text}}</v-list-tile-title>
                    </v-list-tile>
                </v-list>
            </v-menu>
            <v-btn flat color="pink" @click="singout">
                <span>Sign out</span>
                <v-icon>exit_to_app</v-icon>
            </v-btn>
        </v-toolbar>
        <v-navigation-drawer v-model="drawer" app class="secondary white--text">
            <v-layout column align-center>
                <v-flex class="mt-3">
                    <v-avatar size="200">
                        <img src="/images/avatar-1.png" alt="">
                    </v-avatar>
                    <p class="subheading mt-1 text-xs-center primary--text">Science Sucker</p>
                </v-flex>
                <v-flex class="my-2">
                    <PopUp @ProjectAdded="snackbar=true"></PopUp>
                </v-flex>
            </v-layout>
            <v-list>
                <v-list-tile v-for="link in links" :key="link.text" router :to="link.route">
                    <v-list-tile-action>
                        <v-icon dark>{{link.icon}}</v-icon>
                    </v-list-tile-action>
                    <v-list-tile-content>
                        <v-list-tile-title class="white--text">{{link.text}}</v-list-tile-title>
                    </v-list-tile-content>
                </v-list-tile>
            </v-list>
        </v-navigation-drawer>
    </nav>
</template>
<script>
import PopUp from './popUp';

export default {
    data(){
        return{
            drawer:true,
            links:[
                {icon:'dashboard',text:'Dashboard',route:'/'},
                {icon:'create',text:'Register',route:'/register'},
                {icon:'get_app',text:'Login',route:'/login'},
                {icon:'people',text:'Team',route:'/team'}
            ],
            snackbar:false
        }
    },
    components:{
        PopUp
    },
    methods:{
        singout(){
            alert("Sign out!");
        }
    }
    
}
</script>
<style>
a:hover {
    color: #18FFFF;
    text-decoration: underline;
}
</style>

