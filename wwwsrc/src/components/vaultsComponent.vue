<template>
<div class="vaults-cards card m-2 bg-primary" @click="setActiveVault()">
  <div class="row">
    <div class="col-2">

  <i class="fa fa-times text-danger" v-if="profile.id == vaultProp.creatorId" @click.stop="deleteVault()" aria-hidden="true"></i>
    </div>
    <div class="col-10">
  <h2 class="text-light">{{vaultProp.name}}</h2>
  </div>
    </div> 
  <div class="row">
    <div class="col">
  <img class="vault-img" src="https://gleason-group.net/wp-content/uploads/2018/03/vault-1.jpg" alt="pic"> -
    </div>
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
.vaults-cards{
  height: 30vh;
  width: 20vw;
  border-radius: 25px;
}
.vault-img{
  height: 25vh;
  width: 20vw;
  border-radius: 25px;
}
</style>