<template>
  <div class="home container-fluid">
    <div class="row">
    <keeps-component v-for="keep in keeps" :key="keep.id" :keepProp="keep"/>
    </div>
  </div>
</template>

<script>
import keepsComponent from "../components/keepsComponent"
export default {
  name: "home",
  mounted(){
    this.$store.dispatch("getKeeps")
  },
  data(){
    return {
      keepData:{}
    }
  },
  computed: {
    keeps(){
      return this.$store.state.keeps
    }
  },
  methods: {},
  components: {keepsComponent}
};
</script>
