<template>
  <div class="home container-fluid"> 
<div class="row">
     <div v-if="$auth.isAuthenticated">
      <form @submit.prevent="createKeep()">
        <div class="form-group card">
      <button class="btn btn-success" type="submit">Create Keep</button>
      <input class="form-control" placeholder="Keep Title ... " type="text" v-model="newKeep.name">
      <input class="form-control" placeholder="Keep desc ... " type="text" v-model="newKeep.description">
      <input class="form-control" placeholder="Keep img ... " type="text" v-model="newKeep.img">
       <!-- <input class="form-control" placeholder="profile Id ... " type="text" v-model="keepData.creatorId">
       <input class="form-control" placeholder=" Id ... " type="text" v-model="keepData.id"> -->
      <!-- NOTE d1346e0c-3732-45fc-ad6b-237fa1a0b73d is test id -->
        </div>
      </form>
    </div>
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
    // this.$store.dispatch("getActiveKeep" , this.$route.params.keepId)
    // this.$store.dispatch("getProfile" , this.$route.params.profile)
    // console.log(this.profile);

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
  // setActiveKeep() {
  //     this.$store.dispatch("setActiveKeep", this.keepData)
  // },
  createKeep(){
    this.$store.dispatch("createKeep" , this.newKeep)
    console.log(this.newKeep);
  }
},
  components: {keepsComponent},
}
</script>
