<template>
  <div class="home container-fluid"> 
<div class="row">
     <div v-if="$auth.isAuthenticated">
      <form @submit.prevent="createKeep">
        <div class="form-group card">
      <button class="btn btn-success" type="submit">Create Keep</button>
      <input class="form-control" placeholder="Keep Title ... " type="text" v-model="keepData.name">
      <input class="form-control" placeholder="Keep desc ... " type="text" v-model="keepData.description">
      <input class="form-control" placeholder="Keep img ... " type="text" v-model="keepData.img">
        </div>
      </form>

    </div>
<keeps-component class="btn" type="button" data-toggle="modal" data-target="#keepModal" v-for="keep in keeps" :key="keep.id" :keepProp="keep"/>
    </div>
  </div>
</template>

<script>
import keepDetailsComponent from "../components/keepDetailsComponent"
import keepsComponent from "../components/keepsComponent"
import ProfilePage from "../pages/ProfilePage"
export default {
  name: "home",
  props:["keepProp"],
  mounted(){
    this.$store.dispatch("getKeeps"),
    this.$store.dispatch("getActiveKeep" , this.$route.params.keepId)
    this.$store.dispatch("getProfile" , this.profile)
    // console.log(this.profile);

  },
  data(){
    return {
      keepData: {
        // creatorId : keepProp.creatorId
      }
    }
  },
  computed: {
    keeps(){
      return this.$store.state.keeps
    },
     activeKeep() {
      return this.$store.state.activeKeep
    },
  },
  methods: {
  setActive() {
          this.$store.dispatch("setActiveKeep", this.keepData)
  },
  createKeep(){
    this.$store.dispatch("createKeep" , this.keepData)
    // this.keepData = { creatorId: "profile" };
    // console.log(this.keepData);
  }
},
  components: {keepsComponent},
}
</script>
