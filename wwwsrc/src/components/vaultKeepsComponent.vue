<template>
 <div class="vault-keeps-cards card col m-2" >
    <i class="fa fa-times text-danger fa-3x" v-if="profile.id == activeVault.creatorId" @click="deleteVaultKeep()" />
  <h2>{{activeVaultKeepProp.name}}</h2>
  <h2>{{activeVaultKeepProp.description}}</h2>
  <!-- <h2>{{searchedProfile.creator.name}}</h2> -->
    <img :src="activeVaultKeepProp.creator.picture" width="100" height="100" alt="pic">

    </div>
</template>

<script>
export default {
name: "vault-keeps-component" ,
  props:["keepProp" , "activeVaultKeepProp" , "vaultProp"],
 mounted(){
   this.$store.dispatch("getKeepsByVaultId" , this.$route.params.vaultId)
   this.$store.dispatch("getActiveVaultKeeps" , this.$route.params.vaultId)
  //  this.$store.dispatch("getActiveVaults" , this.$route.params.profileId)
 },
 data() {
    return {
    //   deleteVaultKeep:{
    //     vaultId : this.activeVault.id ,
    //     keepId : this.activeKeep.id
    //   }
     }
    },
    computed:{
      activeVaultKeeps(){
        return this.$store.state.activeVaultKeeps
    },
     profile(){
       return this.$store.state.profile
    },
      keep() {
      return this.$store.state.keeps
    },
    vault(){
      return this.$store.state.vaults
    },
    activeVault(){
      return this.$store.state.activeVault
    },
    activeKeep(){
      return this.$store.state.activeKeep
    }
    },
    methods:{
      deleteVaultKeep(){
      // this.$store.dispatch("deleteVaultKeep", this.activeVault.id)
      // this.deleteVaultKeep.keepId = this.activeKeep.id;
      // this.deleteVaultKeep.vaultId = this.activeVault.id;
        // let deletedVaultKeep = {};
        // deletedVaultKeep.keep = keep;
        // deletedVaultKeep.route = this.$route.params.vaultId;
      this.$store.dispatch("deleteVaultKeep", this.activeVaultKeepProp.vaultKeepId)
      },
    //   setActiveKeep(){
    //   this.$store.dispatch("setActiveKeep" , this.keepProp)
    //   this.$store.dispatch("getVaultsByProfile" , this.profile.id)
    //   this.$store.dispatch("keepViewsCount" , this.keepProp)
    // }
}
}
</script>

<style>

</style>