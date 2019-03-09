<template>
    <div class="team">
        <h1 class="subheading grey--text">Team</h1>
        <v-container class="my-2">
            <v-layout row wrap>
                <v-flex xs12 sm6 md4 lg3 v-for="person in Persons" :key="person.name">
                    <v-card class="text-xs-center ma-3">
                        <v-responsive class="pt-4">
                            <v-avatar size="200" class="primary">
                                <img src="/images/avatar-1.png">
                            </v-avatar>
                        </v-responsive>
                        <v-card-text>
                            <div class="subheading">{{person.name}}</div>
                            <div class="grey--text">{{person.role}}</div>
                        </v-card-text>
                        <v-card-actions>
                            <v-btn flat color="grey" class="mx-auto">
                                <v-icon left small>message</v-icon>
                                <span>Message</span>
                            </v-btn>
                        </v-card-actions>
                    </v-card>
                </v-flex>
            </v-layout>
        </v-container>
    </div>
</template>
<script>
export default {
    data(){
        return {
            Persons:[
                {name:'Robin',role:'Founder'},
                {name:'Tanim',role:'CEO'},
                {name:'Tuhin',role:'Sponsor'},
                {name:'Tuhin',role:'Sponsor'},
                {name:'Tuhin',role:'Sponsor'}
            ]
        }
    }
}
</script>
