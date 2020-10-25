<template>
<div class="card"> hello world 
  <!-- <div><h2>{{vaultProp.name}}</h2>
  <h2>{{vaultProp.description}}</h2> 
  <h2>{{keepProp.creator.name}}</h2> 
  <img src="https://cdn0.iconfinder.com/data/icons/most-usable-logos/120/Reddit-512.png" width="100" height="100" alt="pic"> -
    </div> --->
    </div> 
</template>

<script>
export default {
  name: "vaults-component",
  props:["keepProp, vaultProp"],
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
}
</script>

<style>

</style>