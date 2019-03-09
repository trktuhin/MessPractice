<template>
  <div>
      <v-btn color="success">Success</v-btn>
      <v-btn color="error">Error</v-btn>
      <v-btn depressed color="warning">Warning</v-btn>
      <v-btn color="info">Info</v-btn>
      <v-btn color="info">Info</v-btn>

      <v-btn fab large class="pink white--text hidden-sm-and-down">
        <v-icon>favorite</v-icon>
      </v-btn>
<div class="my-3">
      <v-layout row class="mb-3 ml-3">
        <v-tooltip top>
          <v-btn flat class=" white--text" @click="sortBy('title')" slot="activator">
            <v-icon small left>folder</v-icon>
            <span>Sort by title</span>
          </v-btn>
          <span>Click to sorty by project title</span>
        </v-tooltip>

        <v-tooltip top>
          <v-btn flat class=" white--text" @click="sortBy('person')" slot="activator">
            <v-icon small left>person</v-icon>
            <span>Sort by person</span>
          </v-btn>
          <span>Click to sorty by person</span>
        </v-tooltip>
      </v-layout>

      <div class="v-card white pa-0" v-for="project in projects" :key="project.title">
          <v-layout row wrap :class="`pa-3 ml-2 project ${project.status}`">
            <v-flex xs12 md6>
              <div class="caption grey--text">Project title</div>
              <div>{{project.title}}</div>
            </v-flex>
            <v-flex xs4 md2>
              <div class="caption grey--text">Person</div>
              <div>{{project.person}}</div>
            </v-flex>
            <v-flex xs4 md2>
              <div class="caption grey--text">Due by</div>
              <div>{{project.due}}</div>
            </v-flex>
            <v-flex xs4 md2>
              <div>
                <v-chip :class="`white--text ${project.status}`">{{project.status}}</v-chip>
              </div>
            </v-flex>
          </v-layout>
      </div>
</div>
<div class="ma-2">
  <v-expansion-panel>
    <v-expansion-panel-content v-for="project in myProjects" :key="project.title">
      <div slot="header">{{project.title}}</div>
      <v-card>
        <v-card-text>
          <div class="px-4 grey--text">
            {{project.content}}
          </div>
        </v-card-text>
      </v-card>
    </v-expansion-panel-content>
  </v-expansion-panel>
</div>

    </div>
</template>

<script>
export default {
  data () {
    return {
      projects:[
        {title:'First Project',person:'Science sucker', due:'1 jan 2019',status:'ongoing',content:'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Totam minima laudantium ea deleniti nisi sit magni earum? Nam porro veritatis quibusdam veniam dicta delectus ut maiores impedit, ipsam architecto reprehenderit.'},
        {title:'Second Project',person:'Mr X', due:'1 jan 2019',status:'complete',content:'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Totam minima laudantium ea deleniti nisi sit magni earum? Nam porro veritatis quibusdam veniam dicta delectus ut maiores impedit, ipsam architecto reprehenderit.'},
        {title:'Third Project',person:'Cock sucker', due:'1 jan 2019',status:'complete',content:'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Totam minima laudantium ea deleniti nisi sit magni earum? Nam porro veritatis quibusdam veniam dicta delectus ut maiores impedit, ipsam architecto reprehenderit.'},
        {title:'New Project',person:'Science sucker', due:'1 jan 2019',status:'ongoing',content:'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Totam minima laudantium ea deleniti nisi sit magni earum? Nam porro veritatis quibusdam veniam dicta delectus ut maiores impedit, ipsam architecto reprehenderit.'},        
        {title:'Fourth Project',person:'Pussy sucker', due:'1 jan 2019',status:'overdue',content:'Lorem ipsum dolor, sit amet consectetur adipisicing elit. Totam minima laudantium ea deleniti nisi sit magni earum? Nam porro veritatis quibusdam veniam dicta delectus ut maiores impedit, ipsam architecto reprehenderit.'}

      ]
    }
  },
  computed:{
      fullName(){
          return this.$store.getters.getFullName;
      },
      isAuthenticated(){
        return this.$store.getters.isAuthenticated;
      },
      myProjects(){
        return this.projects.filter(project=>project.person=="Science sucker");
      }
  },
  methods:{
    sortBy(prop){
      this.projects.sort((a,b)=>a[prop]<b[prop]?-1:1);
    }
  }
}
</script>

<style>
.project.complete{
  border-left: 4px solid #3cd1c2;
}
.project.ongoing{
  border-left: 4px solid orange;
}
.project.overdue{
  border-left: 4px solid tomato;
}
.v-chip.complete{
  background-color: #3cd1c2;
}
.v-chip.ongoing{
  background-color: orange;
}
.v-chip.overdue{
  background-color: tomato;
}
</style>
