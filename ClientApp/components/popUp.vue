<template>
    <v-dialog max-width="600px" v-model="dialog">
        <v-btn slot="activator" class="success">
            Add new project
        </v-btn>
        <v-card>
            <v-card-title>
                <h2>Add a new project</h2>
            </v-card-title>
            <v-form class="px-3">
                <v-text-field label="Title" prepend-icon="folder"></v-text-field>
                <v-textarea label="Description" prepend-icon="edit"></v-textarea>
                <v-menu>
                    <v-text-field :value="formattedDate" slot="activator" prepend-icon="date_range" label="Due Date"></v-text-field>
                    <v-date-picker color="black" v-model="dueDate"></v-date-picker>
                </v-menu>
                <v-spacer></v-spacer>
                <v-btn class="success my-3" @click="submitProject" :loading="loading">Sumbit</v-btn>
            </v-form>
        </v-card>
    </v-dialog>
</template>
<script>
import format from 'date-fns/format'
export default {
    data(){
        return{
            dueDate:null,
            loading:false,
            dialog:false
        }
    },
    methods:{
        submitProject(){
            this.loading=true;
            setTimeout(()=>{
                this.loading=false;
                this.dialog=false;
                this.$emit('ProjectAdded');
            },3000);
        }
    },
    computed:{
        formattedDate(){
            return this.dueDate? format(this.dueDate,'DD MMM YYYY'):'';
        }
    }
}
</script>
