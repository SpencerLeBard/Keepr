<template>
<div class="vaults-cards card m-2" @click="setActiveVault()">
  <i class="fa fa-times text-danger" v-if="profile.id == vaultProp.creatorId" @click="deleteVault()" aria-hidden="true"></i>
  <div><h2>{{vaultProp.name}}</h2>
  <h2>{{vaultProp.description}}</h2> 
  <h2>{{vaultProp.creator.name}}</h2> 
  <img src="https://cdn0.iconfinder.com/data/icons/most-usable-logos/120/Reddit-512.png" width="100" height="100" alt="pic"> -
    </div> 
    </div>
</template>

<script>
export default {
  name: "vaults-component",
  props:["vaultProp"],
   data(){
    return{
    }
  },
   computed:{
    profile(){
      return this.$store.state.profile
    },
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    keep() {
      return this.$store.state.keeps
    },
    vault(){
      return this.$store.state.vaults
    }
  },
  methods: {
     deleteVault(){
      this.$store.dispatch("deleteVault",this.vaultProp.id)
},
    setActiveVault(){
      this.$store.dispatch("setActiveVault" , this.vaultProp)
      this.$store.dispatch("getKeepsByVaultId" , this.vaultId)
      this.$router.push({name: "VaultPage", params: { vaultId:this.vaultProp.id}})

  },    
  }
}

</script>

<style>

</style>