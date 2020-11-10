<template>
 <div class="vault-keeps-cards card m-2 container bg-primary" >
   <div class="row">
     <div class="col-2">
    <i class="fa fa-times text-danger fa-2x" v-if="profile.id == activeVault.creatorId" @click="deleteVaultKeep()" />
     </div>
     <div class="col-8 text-center">
  <h2 class="text-light">{{activeVaultKeepProp.name}}</h2>
     </div>
   </div>
   <div class="row">
    <img class="vault-keeps-img" :src="activeVaultKeepProp.img" alt="pic">
   </div>
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
.vault-keeps-cards{
  height: 42vh;
  width: 23vw;
  border-radius: 25px;
}
.vault-keeps-img{
  height:36vh;
  width: 24vw;
  border-radius: 25px;
}
</style>