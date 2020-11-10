<template>
<div>
 <div class="profile-keeps-cards card m-2 bg-primary" >
   <div class="row">
   <div class="col-2">
      <i class="fa fa-times text-danger" v-if="profile.id == profileKeepsProp.creatorId" @click="deleteKeep()" aria-hidden="true"></i>
   </div>
   <div class="col">

  <div><h2 class="text-light">{{profileKeepsProp.name}}</h2> 
   </div>
    </div>
   </div>
    <div class="row">
    <div class="col">
  <img class="profile-keeps-img" :src="profileKeepsProp.img" alt="pic">
    </div>
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
  height: 30vh;
  width: 20vw;
  border-radius: 25px;
}
.profile-keeps-img{
  height: 25vh;
  width: 20vw;
  border-radius: 25px;
}

</style>