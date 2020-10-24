<template>
<div class="keep-cards card col-3 m-2" @click ="setActiveKeep"> 
  <h2>{{keepProp.name}}</h2>
  <h2>{{keepProp.description}}</h2>
  <h2>{{keepProp.creator.name}}</h2>
  <img src="https://cdn0.iconfinder.com/data/icons/most-usable-logos/120/Reddit-512.png" width="100" height="100" alt="pic">
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
        <p>Description: {{activeKeep.description}}</p>
        <p>Views: {{activeKeep.views}}</p>
        <p>Shares: {{activeKeep.shares}}</p>
        <p>Keeps: {{activeKeep.keeps}}</p>
        <p>{{activeKeep.img}}</p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-primary">Save to Vault</button>
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
    }
  },
  mounted(){
    this.$store.dispatch("getActiveKeep" , this.$route.params.keepId)
  },
  computed:{
    profile(){
      return this.$store.state.profile
    },
    // modalId(){
    //   return "modal" + this.keepData.id
    //},
    activeKeep() {
      return this.$store.state.activeKeep
    },
    keep() {
      return this.$store.state.keeps
    },
  },
  methods:{
    viewProfile(){
      this.$router.push({name: "Profile", params: { profileId:this.keepProp.creator.id}})
  },
    setActiveKeep(){
      this.$store.dispatch("setActiveKeep" , this.keepProp)
      // console.log(this.keepProp.name);
    }
},
// components:
// {keepDetailsComponent }
}
</script>

<style>
.keep-cards{
  height: 40vh;
  width: 25vw;
}
.truncate {
  width: 25vw;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

</style>