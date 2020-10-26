<template>
  <div class="profile container-fluid">
    <div class="row">
      <div class="col">

    <h1> Welcome to {{searchedProfile.name}}'s Profile!</h1>
    <img :src="searchedProfile.picture" width="100" height="100" alt="pic">
    <div v-if="searchedProfile.id == profile.id">
      <div class="col-6">
      <form @submit.prevent="createVault()">
        <div class="form-group card">
      <button class="btn btn-success" type="submit">Create Vault</button>
      <input class="form-control" placeholder="Keep Name ... " type="text" v-model="newVault.name">
      <input class="form-control" placeholder="Keep Desc ... " type="text" v-model="newVault.description">
      <input type="checkbox" v-model="newVault.isPrivate"> Private?
        </div>
      </form>
      </div>
    </div>
      </div>
    </div>
      <div class="row">
        <div class="col-3">
      <!-- <keeps-component v-for="keep in keeps" :key="keep.id" :keepProp="keep"/>  -->
      <vaults-component v-for="vault in vaults" :key="vault.id" :vaultProp="vault"/>
        </div>
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
     createVault(){
    this.$store.dispatch("createVault" , this.newVault)
    console.log(this.newVault);
  }
  },
  components: {vaultsComponent , keepsComponent},
}
</script>

<style>

</style>