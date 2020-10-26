<template>
  <div class="profile container-fluid">
    <h1> Welcome to {{searchedProfile.name}}'s Profile!</h1>
    <img :src="searchedProfile.picture" width="100" height="100" alt="pic">
    <div class="row">
      <!-- <keeps-component v-for="keep in keeps" :key="keep.id" :keepProp="keep"/>  -->
      <vaults-component v-for="vault in vaults" :key="vault.id" :vaultProp="vault"/>
      </div>
  </div>
</template>

<script>
import keepsComponent from "../components/keepsComponent";
import vaultsComponent from "../components/vaultsComponent";
export default {
  name: "profile",
  props: ["vaultProp" , "keepProp"],
  mounted(){
    this.$store.dispatch("getSearchedProfile", this.$route.params.profileId);
    this.$store.dispatch("getVaults" , this.$route.params.profileId)
    //  this.$store.dispatch("getProfileKeeps", this.$route.params.profileId);
  },
  data(){
    return{
      vaultData: {
      },
      newVault:{
      },
    }
    },
  computed: {
    keeps(){
      return this.$store.state.profileKeeps;
    },
    profile(){
      return this.$store.state.profile;
    },
    vaults(){
      return this.$store.state.vaults
    },
    searchedProfile(){
      return this.$store.state.searchedProfile
    }
  },
  methods: {
       viewProfile(){
      this.$router.push({name: "Profile", params: { profileId:this.keepProp.creator.id}})
  },

  },
  components: {vaultsComponent , keepsComponent},
}
</script>

<style>

</style>