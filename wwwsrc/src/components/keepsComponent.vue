<template>
<div class="keep-cards card m-2 bg-primary" @click="setActiveKeep()"> 
   <!-- <i class="fa fa-times text-danger" v-if="profile.id == keepProp.creatorId" @click.stop="deleteKeep()" aria-hidden="true"></i> -->
  <!-- <h2>{{keepProp.name}}</h2>
  <h2>{{keepProp.description}}</h2>
  <h2>{{keepProp.creator.name}}</h2>
  <h2>{{keepProp.creator.picture}}</h2> -->
  <img class="keeps-img" :src="keepProp.img" width="100" height="100" alt="pic">

  <!-- <h2>{{keepProp.creator.picture}}</h2>
  //NOTE PUT ^^ IN IMG TAG AND MAKE IT FIT SNUG
  <img src="https://cdn0.iconfinder.com/data/icons/most-usable-logos/120/Reddit-512.png" width="100" height="100" alt="pic"> -->
  <!-- <img :src="keepProp.creator.picture" width="100" height="100" alt="pic" @click="viewProfile()"> -->
  <div class="modal fade"  id="keepModal" tabindex="-1" 
  data-toggle="modal" data-backdrop="static" data-keyboard="false">
  <div class="modal-dialog" role="document">
    <div class="modal-content text-center">
      <div class="modal-header text-center">
        <h5 class="modal-title text-center">{{activeKeep.name}}</h5>
        <button type="button" class="close" data-dismiss="" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body" @click.stop v-if="activeKeep.creator">
        <!-- <p>Name: {{activeKeep.name}}</p>
        <p>Description: {{activeKeep.description}}</p>
        <p>Views: {{activeKeep.views}}</p>
        <p>Shares: {{activeKeep.shares}}</p>
        <p>Keeps: {{activeKeep.keeps}}</p> -->
        <p>Creator: {{activeKeep.creator.name}}</p>
        <img :src="activeKeep.creator.picture" width="50" height="50" alt="pic" class="keep-avatar m-1" @click="viewProfile()">
        <img :src="activeKeep.img" width="450" height="450" alt="pic">
      </div>
      <div class="modal-footer row" @click.stop >
        <!-- <form class="col" @submit.prevent="createVaultKeep()" >
            <button type="submit" class="btn btn-danger"  >Save to Vault</button>
          <select class="form-control" v-model="newVaultKeep"  >
            <option v-for="vault in vaults" :key="vault.id" :vaultProp="vault" > {{vaultProp.name}}</option>
            </select>
        </form>
        <button type="button" class="btn btn-primary" @submit.prevent="createVaultKeep()" >Save to Vault</button>  
            NOTE ^^TRY ABOVE IF BELOW ISINT WORKING -->           
   <form class="col d-flex" @submit.prevent="createVaultKeep()">
            <button type="submit" class="btn btn-danger" @click="increaseKeepsCount()" >Save to Vault</button>
          <select class="form-control" v-model="newVaultKeep.vaultId" >
            <option v-for="vault in vaults" :key="vault.id" :vaultProp="vault" :value="vault.id"> {{vault.name}}</option>
            </select>
        </form>
      </div>
    </div>
  </div>
</div>
</div> 
</template>

<script>
import vaultComponent from "../components/vaultsComponent"
export default {
  name: "keeps-component",
  props:["keepProp" , "vaultProp"],
   mounted(){
     this.$store.dispatch("getProfile", this.$route.params.profileId);
    // this.$store.dispatch("getVaultsByProfile" , this.$route.params.vaultId)
    // this.$store.dispatch("getActiveKeep" , this.$route.params.keepId)

   },
  data(){
    return{
      newVaultKeep: {
        keepId: 0 ,
        vaultId : 0 
      },
    }
  },
  computed:{
    profile(){
      return this.$store.state.profile
    },
    activeKeep() {
      return this.$store.state.activeKeep;
    },
    activeVault() {
      return this.$store.state.activeVault;
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
      this.$store.dispatch("getSearchedProfile" , this.keepProp.creator.id)
      this.$router.push({name: "Profile", params: { profileId : this.keepProp.creator.id}})

      // this.$store.dispatch("getVaultsByProfile" , this.profile.id)
      // this.$store.dispatch("getProfileKeeps" , this.profile.id)
      //NOTE MAYBE THIS TO GET INFO WHEN ROUTING

  },
    setActiveKeep(){
      this.$store.dispatch("setActiveKeep" , this.keepProp)
      this.$store.dispatch("getVaultsByProfile" , this.profile.id)
      // this.$store.dispatch("keepViewsCount" , this.keepProp)
    },
    // clearActiveKeep(){
    //   this.$store.dispatch("clearActiveKeep")

    // },
    deleteKeep(){
      this.$store.dispatch("deleteKeep",this.keepProp.id)
},
    createVaultKeep(){
      this.newVaultKeep.keepId = this.activeKeep.id;
      this.$store.dispatch("createVaultKeep" , this.newVaultKeep)
    //NOTE TRY BELOW IF THIS DOESNT WORK 
      // this.$store.dispatch("createVaultKeep" , this.activeKeep.id)
      // this.$store.dispatch("createVaultKeep" , this.activeVault)
      } ,
      // keepViewsCount(){ 
      // this.$store.dispatch("keepViewsCount" , this.keepProp.id)
      // }
      increaseKeepsCount(){
      this.$store.dispatch("keepsCount" , this.keepProp)

      }
  },
    components: {vaultComponent}
}

</script>

<style>
.keep-cards{
  height: 42vh;
  width: 23vw;
  border-radius: 25px;
}
.keeps-img{
  height:40vh;
  width:22vw;
  border-radius: 25px;
}

</style>