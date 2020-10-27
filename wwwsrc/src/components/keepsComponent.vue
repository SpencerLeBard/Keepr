<template>
<div class="keep-cards card col-3 m-2" @click="setActiveKeep() + keepViewsCount()"> 
   <i class="fa fa-times text-danger" v-if="profile.id == keepProp.creatorId" @click="deleteKeep()" aria-hidden="true"></i>
  <h2>{{keepProp.name}}</h2>
  <h2>{{keepProp.description}}</h2>
  <h2>{{keepProp.creator.name}}</h2>
  <!-- <h2>{{keepProp.creator.picture}}</h2>
  //NOTE PUT ^^ IN IMG TAG AND MAKE IT FIT SNUG
  <img src="https://cdn0.iconfinder.com/data/icons/most-usable-logos/120/Reddit-512.png" width="100" height="100" alt="pic"> -->
  <img :src="keepProp.creator.picture" width="100" height="100" alt="pic" @click="viewProfile()">
  <div class="modal fade"  id="keepModal" tabindex="-1" 
  data-toggle="modal" data-backdrop="static" data-keyboard="false">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">{{activeKeep.name}}</h5>
        <button type="button" class="close" data-dismiss="" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <p>Name: {{activeKeep.name}}</p>
        <!-- <p>creator: {{activeKeep.creator}}</p> -->
        <p>Description: {{activeKeep.description}}</p>
        <p>Views: {{activeKeep.views}}</p>
        <p>Shares: {{activeKeep.shares}}</p>
        <p>Keeps: {{activeKeep.keeps}}</p>
        <p>{{activeKeep.img}}</p>
      </div>
      <div class="modal-footer">
        <!-- <button type="button" class="btn btn-primary" @click="createVaultKeep()" >Save to Vault</button> -->
        <form @submit.prevent="createVaultKeep()">
            <button class="btn btn-danger">Save to Vault</button>
          <select class="form-control" v-model="newVaultKeep.vaultId" >
            <option data-offset="" v-for="vault in vaults" :key="vault.id" :vaultProp="vault"> {{vault.name}}</option>
            </select>
        </form>
      </div>
    </div>
  </div>
</div>
</div> 
</template>

<script>
export default {
  name: "keeps-component",
  props:["keepProp" , "vaultProp"],
  data(){
    return{
      newVaultKeep: {
        vaultId: 2 , 
        keepId: 2 ,
      },
    }
  },
  // mounted(){
  //   this.$store.dispatch("getActiveKeep" , this.$route.params.keepId)
  // },
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
    vaults(){
      return this.$store.state.vaults
    }
  },
  methods:{

    viewProfile(){
      this.$router.push({name: "Profile", params: { profileId:this.keepProp.creator.id}})
      this.$store.dispatch("getSearchedProfile" , this.keepProp.creator.id)
  },
    setActiveKeep(){
      this.$store.dispatch("setActiveKeep" , this.keepProp)
      // this.$store.dispatch("keepViewsCount" , this.keepProp)
    },
    deleteKeep(){
      this.$store.dispatch("deleteKeep",this.keepProp.id)
},
    createVaultKeep(){
      this.$store.dispatch("createVaultKeep" , newVaultKeep)
      } ,
      keepViewsCount(){ 
      this.$store.dispatch("keepViewsCount" , this.keepProp.id)
      }
  }
}

</script>

<style>
.keep-cards{
  height: 40vh;
  width: 25vw;
}
/* .modal {
  z-index: -1;
} */

</style>