<template>
<div class="keep-cards card col-3">
  <h2>{{keepProp.name}}</h2>
  <h2>{{keepProp.description}}</h2>
   <img :src="" alt="http://placehold.it/100x100" />
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
  methods:{},
  components:{}
}
</script>

<style>

</style>