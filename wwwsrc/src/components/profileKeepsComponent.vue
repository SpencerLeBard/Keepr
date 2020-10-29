<template>
  <div>
 <div class="profile-keeps-cards card col m-2" >
      <i class="fa fa-times text-danger" v-if="profile.id == profileKeepsProp.creatorId" @click="deleteKeep()" aria-hidden="true"></i>
  <div><h2>{{profileKeepsProp.name}}</h2> 
   <h2>{{profileKeepsProp.description}}</h2>
    </div> 
    </div>
  </div>
</template>

<script>
export default {
name: "profile-keeps-component",
props:["keepsProp" , "profileKeepsProp"],
mounted(){
    this.$store.dispatch("getSearchedProfile", this.$route.params.profileId);
     this.$store.dispatch("getProfileKeeps", this.$route.params.profileId);
     this.$store.dispatch("getKeepsByCreatorId", this.$route.params.profileId);
  },
computed: {
    keep(){
      // this.$store.commit("getProfileKeeps" , this.$route.params.profileId)
      return this.$store.state.profileKeeps;
    },
    profile(){
      return this.$store.state.profile;
    },
    searchedProfile(){
      return this.$store.state.searchedProfile
    },
    keeps(){
      return this.$store.state.keeps
    }
  },
  methods:{
      deleteKeep(){
      this.$store.dispatch("deleteKeep",this.profileKeepsProp.id)
},
  }

}
</script>

<style>
.profile-keeps-cards{
  height: 40vh;
  width: 25vw;
}
</style>