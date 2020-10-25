<template>
  <div class="home container-fluid"> 
<div class="row">
<keeps-component class="btn" type="button" data-toggle="modal" data-target="#keepModal" v-for="keep in keeps" :key="keep.id" :keepProp="keep"/>
    </div>
  </div>
</template>

<script>
import keepDetailsComponent from "../components/keepDetailsComponent"
import keepsComponent from "../components/keepsComponent"
import ProfilePage from "../pages/ProfilePage"
export default {
  name: "home",
  props:["keepProp" , "index"],
  mounted(){
    this.$store.dispatch("getKeeps"),
    this.$store.dispatch("getActiveKeep" , this.$route.params.keepId)

  },
  data(){
    return {
    }
  },
  computed: {
    keeps(){
      return this.$store.state.keeps
    },
     activeKeep() {
      return this.$store.state.activeKeep
    },
  },
  methods: {
        setActive() {
          this.$store.dispatch("setActiveKeep", this.keepData)
  }
},
  components: {keepsComponent},
}
</script>
