<template>
  <div class="profile container-fluid">
    <h1> Welcome to {{profile.name}}'s Profile!</h1>
    <div class="row">
      <!-- 
      NOTE THERE WILL BE KEEPS AND THEN VAULTS COMPS
      <keeps-component v-for="keep in keeps" :key="keep.id" :keepProp="keep"/> 
      <vaults-component v-for="vault in vaults" :key="vault.id" :vaultProp="vault"/> -->
    </div>
  </div>
</template>

<script>
import keepsComponent from "../components/keepsComponent";
export default {
  name: "Profile",
  mounted(){
    //  this.$store.dispatch("getProfileBlogs", this.$route.params.profileId);
     this.$store.dispatch("getSearchedProfile", this.$route.params.profileId);
    //NOTE pretty sure its "userId" or "creatorId"
  },
  computed: {
    keeps(){
      return this.$store.state.profileKeeps;
    },
    profile(){
      return this.$store.state.profile;
    }
  },
  methods: {
       viewProfile(){
      this.$router.push({name: "Profile", params: { profileId:this.keepProp.creator.id}})
  },
  },
  componenets:
      {keepsComponent},
}
</script>

<style>

</style>