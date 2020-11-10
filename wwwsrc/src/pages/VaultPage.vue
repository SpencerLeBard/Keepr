<template>
  <div class="vault-page container-fluid">
    <div class="row">
      <h1 class="text-light"> Vault Name: {{activeVault.name}} </h1>
      <i class="fa fa-times text-danger fa-2x" v-if="profile.id == activeVault.creatorId" @click="deleteVault()" aria-hidden="true"></i>
    </div>
    <div class="row">
    <h1 class="text-light">Keeps in Vault:</h1>
    </div>
    <div class="row">
    <vault-keeps-component v-for="activeVaultKeep in activeVaultKeeps" :key="activeVaultKeep.id" :activeVaultKeepProp="activeVaultKeep" />
    </div>
  </div>
</template>

<script>
import keepsComponent from "../components/keepsComponent"
import vaultKeepsComponent from "../components/vaultKeepsComponent"
export default {
  name: "vault-page" ,
  props:["vaultProp" , "activeVaultKeepsProp"],
  mounted(){
    this.$store.dispatch("getKeepsByVaultId" , this.$route.params.vaultId)
    this.$store.dispatch("getActiveVault" , this.$route.params.profileId)
    this.$store.dispatch("getVaultsByProfile" , this.$route.params.profileId)
    this.$store.dispatch("getActiveVaultKeeps" , this.$route.params.vaultId)
        this.$store.dispatch("getSearchedProfile", this.$route.params.profileId);



  },
  data() {
    return {
    }
    },
  computed: {
    keeps(){
      return this.$store.state.keeps
    },
    activeVault(){
      return this.$store.state.activeVault
    },
    activeVaultKeeps(){
      return this.$store.state.activeVaultKeeps
    },
    profile(){
      return this.$store.state.profile
    },
    },
    methods:{
    deleteVault(){
      this.$store.dispatch("deleteVault",this.activeVault.id)
      this.$router.push({name: "Profile", params: { profileId:this.activeVault.creator.id}})
      },
      viewProfile(){
      this.$router.push({name: "Profile", params: { profileId:this.vaultProp.creator.id}})
      }
    },
    components: {
      keepsComponent , vaultKeepsComponent 
    }
}
</script>

<style>

</style>