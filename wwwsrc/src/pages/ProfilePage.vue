<template>
  <div class="profile container-fluid">
    <div class="row">
      <div class="col-6">
    <div v-if="searchedProfile.id == profile.id">
      <form @submit.prevent="createVault().stopPropigation()">
        <div class="form-group card m-2">
      <button class="btn btn-dark" type="submit">Create Vault</button>
      <input class="form-control" placeholder="Keep Name ... " type="text" v-model="newVault.name">
      <input class="form-control" placeholder="Keep Desc ... " type="text" v-model="newVault.description">
      <input type="checkbox" v-model="newVault.isPrivate"> Private?
        </div>
      </form>
      </div>
    </div>
      <div class="col">
    <img class="m-2" :src="searchedProfile.picture" width="100" height="100" alt="pic">
      </div>
      <div class="col-5">
    <h1 class="text-light"> Welcome to {{searchedProfile.name}}'s Profile!</h1>
      </div>
    <!-- <h1>Total Keeps Count:{{keeps.length}}</h1>
    <h1>Total Public Vaults Count:{{vaults.length}}</h1> -->
    </div>
      <div class="row">
        <h1 class="text-light">Vaults:</h1>
      <vaults-component v-for="vault in vaults" :key="vault.id" :vaultProp="vault"/>
      </div>
      <div class="row">
        <h1 class="text-light">Keeps:</h1>
      <profile-keeps-component v-for="keep in keeps" :key="keep.id" :profileKeepsProp="keep" />
      <!-- {{profileKeeps}} -->
      <!-- {{profileKeepsProp}} -->
      </div>
        </div>
</template>

<script>
import keepsComponent from "../components/keepsComponent";
import vaultsComponent from "../components/vaultsComponent";
import profileKeepsComponent from "../components/profileKeepsComponent";
export default {
  name: "profile",
  props: ["vaultProp" , "keepProp" , "profileKeepsProp"],
  mounted(){
    this.$store.dispatch("getSearchedProfile", this.$route.params.profileId);
    this.$store.dispatch("getVaultsByProfile" , this.$route.params.profileId)
     this.$store.dispatch("getProfileKeeps", this.$route.params.profileId);
    //  this.$store.dispatch("getKeepsByCreatorId", this.$route.params.profileId);
  },
  data(){
    return{
      vaultData: {
      },
      newVault:{
      },
        // profileKeeps:{}
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
    },
  },
  methods: {
      viewProfile(){
      this.$router.push({name: "Profile", params: { profileId:this.keepProp.creator.id}})
  },
     createVault(){
    this.$store.dispatch("createVault" , this.newVault)
  }
  },
  components: {vaultsComponent , profileKeepsComponent}
}
</script>

<style>

</style>