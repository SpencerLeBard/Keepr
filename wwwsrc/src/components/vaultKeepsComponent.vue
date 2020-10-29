<template>
 <div class="vault-keeps-cards card col m-2" >
    <i class="fa fa-times text-danger fa-3x" v-if="profile.id == activeVaultKeepProp.creatorId" @click="deleteVaultKeep(keep)" />
  <h2>{{activeVaultKeepProp.name}}</h2>
  <h2>{{activeVaultKeepProp.description}}</h2>
    </div>
</template>

<script>
export default {
name: "vault-keeps-component" ,
  props:["keepProp" , "activeVaultKeepProp"],
 mounted(){
   this.$store.dispatch("getKeepsByVaultId" , this.$route.params.vaultId)
   this.$store.dispatch("getActiveVaultKeeps" , this.$route.params.vaultId)
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
        let deletedVaultKeep = {};
        deletedVaultKeep.keep = keep.id;
        deletedVaultKeep.vaultId = this.$route.params.vaultId;
      this.$store.dispatch("deleteVaultKeep", deletedVaultKeep)
      debugger
      },
    }
}
</script>

<style>

</style>