<template>
<div class="keep-cards card col-3 m-2" @click="setActiveKeep()"> 
   <i class="fa fa-times text-danger" v-if="profile.id == keepProp.creatorId" @click="deleteKeep()" aria-hidden="true"></i>
  <h2>{{keepProp.name}}</h2>
  <h2>{{keepProp.description}}</h2>
  <h2>{{keepProp.creator.name}}</h2>
  <!-- <h2>{{keepProp.creator.picture}}</h2> -->
  <!-- <img src="https://cdn0.iconfinder.com/data/icons/most-usable-logos/120/Reddit-512.png" width="100" height="100" alt="pic"> -->
  <img :src="keepProp.creator.picture" width="100" height="100" alt="pic" @click="viewProfile()">
  <div class="modal fade"  id="keepModal" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">{{activeKeep.name}}</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <p>Name: {{activeKeep.name}}</p>
        <p>Description: {{activeKeep.description}}</p>
        <p>Views: {{activeKeep.views}}</p>
        <p>Shares: {{activeKeep.shares}}</p>
        <p>Keeps: {{activeKeep.keeps}}</p>
        <p>{{activeKeep.img}}</p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-primary" @click="createVaultKeep()" >Save to Vault</button>
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>
</div> 
</template>

<script>
export default {
  name: "keeps-component",
  props:["keepProp"],
  data(){
    return{
      // newVaultKeep: {
      //   creatorId : keepProp.creatorId ,
      //   vaultId: 2 , 
      //   keepId: 2 ,
      //   creatorId: "d1346e0c-3732-45fc-ad6b-237fa1a0b73d"
      // },
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
  },
  methods:{

    viewProfile(){
      this.$router.push({name: "Profile", params: { profileId:this.keepProp.creator.id}})
      this.$store.dispatch("getSearchedProfile" , this.keepProp.creator.id)
  },
    setActiveKeep(){
      this.$store.dispatch("setActiveKeep" , this.keepProp)
    },
    deleteKeep(){
      this.$store.dispatch("deleteKeep",this.keepProp.id)
},
    createVaultKeep(){
       var newVaultKeep = {
        vaultId: 2 , 
        keepId: 2 ,
        creatorId: "d1346e0c-3732-45fc-ad6b-237fa1a0b73d"
      } 
    this.$store.dispatch("createVaultKeep" , newVaultKeep)
  }
}
}
</script>

<style>
.keep-cards{
  height: 40vh;
  width: 25vw;
}


</style>