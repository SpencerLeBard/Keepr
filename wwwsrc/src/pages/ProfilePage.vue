<template>
  <div class="profile container-fluid">
    <h1> Welcome to {{profile.name}}'s Profile!</h1>
    <div class="row">
      <!-- <keeps-component v-for="keep in keeps" :key="keep.id" :keepProp="keep"/>  -->
     Vaults: <vaults-component v-for="vault in vaults" :key="vault.id" :vaultProp="vault"/>
    </div>
  </div>
</template>

<script>
import keepsComponent from "../components/keepsComponent";
import vaultsComponent from "../components/vaultsComponent";
export default {
  name: "profile",
  props: ["keepProp" , "vaultProp"],
  mounted(){
    this.$store.dispatch("getSearchedProfile", this.$route.params.profileId);
    this.$store.dispatch("getVaults" , vaultData)
    //  this.$store.dispatch("getProfileBlogs", this.$route.params.profileId);

  },
  computed: {
    keeps(){
      return this.$store.state.profileKeeps;
    },
    profile(){
      return this.$store.state.profile;
    },
    vault(){
      return this.$store.state.vaults
    }
  },
  methods: {
       viewProfile(){
      this.$router.push({name: "Profile", params: { profileId:this.keepProp.creator.id}})
  },
  },
  componenets:
      {keepsComponent , vaultsComponent},
}
</script>

<style>

</style>