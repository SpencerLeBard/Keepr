<template>
<div class="keep-cards card col-3 m-2" @click="setActiveKeep()"> 
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
      <div class="modal-body" @click.stop>
        <p>Name: {{activeKeep.name}}</p>
        <!-- <p>creator: {{activeKeep.creator}}</p> -->
        <p>Description: {{activeKeep.description}}</p>
        <p>Views: {{activeKeep.views}}</p>
        <p>Shares: {{activeKeep.shares}}</p>
        <p>Keeps: {{activeKeep.keeps}}</p>
        <p>{{activeKeep.img}}</p>
      </div>
      <div class="modal-footer row" @click.stop>
            <button type="submit" class="btn btn-danger" @submit.prevent="createVaultKeep()" >Save to Vault</button>
        <form class="col">
          <select class="form-control" v-model="newVaultKeep"  >
            <option v-for="vault in vaults" :key="vault.id" :vaultProp="vault"> {{vaults.name}}</option>
            </select>
        </form> 
        <!-- <button type="button" class="btn btn-primary" @submit.prevent="createVaultKeep()" >Save to Vault</button> -->

           <!-- <ul
          class="list-group m-1 col"
          v-for="vault in vaults"
          :key="vault.id">
          <li class="list-group-item">
            <router-link
              class="list-group"
              >{{ vault.name }}</router-link
            >
          </li>
        </ul> -->



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
   mounted(){
    this.$store.dispatch("getVaultsByProfile" , this.$route.params.vaultId)
    this.$store.dispatch("getActiveKeep" , this.$route.params.keepId)
    this.$store.dispatch("getProfile", this.$route.params.profile);

   },
  data(){
    return{
      // newVaultKeep: {
      //   id: 2 ,
      //   vaultId: 1 , 
      //   keepId: 3 ,
      //   creatorId: "d33aace6-b5e0-47c8-a2d9-4c93207627e8" ,
      // },
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
      debugger
      this.$store.dispatch("createVaultKeep" , newVaultKeep)
      } 
      // keepViewsCount(){ 
      // this.$store.dispatch("keepViewsCount" , this.keepProp.id)
      // }
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
select{
    width: 100px;
    text-overflow: scroll;
}

</style>