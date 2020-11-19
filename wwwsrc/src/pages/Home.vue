<template>
  <div class="home container-fluid"> 
<div class="row form-row">
  <div class="col">
     <div v-if="$auth.isAuthenticated">
      <form @submit.prevent="createKeep()">
        <div class="form-group form-card m-2">
      <button class="btn btn-dark" type="submit">Create Keep</button>
      <input class="form-control" placeholder="Keep Title ... " type="text" v-model="newKeep.name">
      <input class="form-control" placeholder="Keep description ... " type="text" v-model="newKeep.description">
      <input class="form-control" placeholder="Keep img url ... " type="text" v-model="newKeep.img">
        </div>
      </form>
  </div>
    </div>
    </div>
    <div class="row">
<keeps-component class="btn" type="button" data-toggle="modal" data-target="#keepModal" v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
    </div>
  </div>
</template>

<script>
import keepsComponent from "../components/keepsComponent"
import ProfilePage from "../pages/ProfilePage"
export default {
  name: "home",
  props:["keepProp"],
  mounted(){
    this.$store.dispatch("getKeeps")
  },
  data(){
    return {
      keepData: {
      },
      newKeep:{
      },
    }
  },
  computed: {
    keeps(){
      return this.$store.state.keeps
    },
     activeKeep() {
      return this.$store.state.activeKeep
    },
    profile(){
      return this.$store.state.profile
    }
  },
  methods: {
  createKeep(){
    this.$store.dispatch("createKeep" , this.newKeep)
  }
},
  components: {keepsComponent},
}
</script>
<style scoped>
.form-card{
  width: 50vw;
}
</style>
