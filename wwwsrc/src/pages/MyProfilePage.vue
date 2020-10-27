<template>
  <div>
    <h1>My Profile ({{profile.name}})</h1>
  </div>
</template>

<script>
import keepsComponent from "../components/keepsComponent";
import vaultsComponent from "../components/vaultsComponent";
export default {
 name: "my-profile",
props: ["vaultProp" , "keepProp"],
mounted(){
    this.$store.dispatch("getProfile", this.$route.params.profile);
},
 computed: {
    keeps(){
      return this.$store.state.profileKeeps;
    },
    profile(){
      return this.$store.state.profile;
    },
    vaults(){
      return this.$store.state.vaults;
    },
},
  components: {vaultsComponent , keepsComponent},

}
</script>

<style>

</style>