<template>
<div>
 <div class="vault-keeps-cards card col m-2" >
  <div><h2>{{activeVaultKeepProp.name}}</h2>
  <h2>{{activeVaultKeepProp.description}}</h2>
  <!-- <h2>{{activeVaultKeepProp.description}}</h2> 
   <h2>{{activeVaultKeepProp.creator.name}}</h2> 
  <img src="https://cdn0.iconfinder.com/data/icons/most-usable-logos/120/Reddit-512.png" width="100" height="100" alt="pic"> -->
    </div> 
    </div>
  </div>
</template>

<script>
export default {
name: "vault-keeps-component" ,
  props:["keepsProp" , "activeVaultKeepProp"],
 mounted(){
   this.$store.dispatch("getKeepsByVaultId" , this.$route.params.vaultId)
   this.$store.dispatch("getActiveVaultKeeps" , this.$route.params.vaultId)
 },
 data() {
    return {}
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
    }
    }
}
</script>

<style>

</style>