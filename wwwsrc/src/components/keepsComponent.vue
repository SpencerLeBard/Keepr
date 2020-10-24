<template>
<div class="keep-cards card col-3 m-2">
  <h2>{{keepProp.name}}</h2>
  <h2>{{keepProp.description}}</h2>
  <img src="https://cdn0.iconfinder.com/data/icons/most-usable-logos/120/Reddit-512.png" width="100" height="100" alt="pic">
   <!-- <img :src="keepProp.img" alt="pic" /> -->
</div> 
</template>

<script>
export default {
  name: "keeps-component",
  props:["keepProp"],
  data(){
    return{}
  },
  computed:{
    profile(){
      return this.$store.state.profile
    }
  },
  methods:{
    viewProfile(){
      this.$router.push({name: "Profile", params: { profileId:this.keepProp.creator.id}})
  }
}
}
</script>

<style>
.keep-cards{
  height: 35vh;
  width: 25vw;
}


</style>