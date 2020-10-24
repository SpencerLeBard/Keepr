<template>
  <div class="profile container-fluid">
    <h1> Welcome to {{profile.name}}'s Profile!</h1>
    <div class="row">
    <keeps-component v-for="keep in keeps" :key="keep.id" :keepProp="keep"/>
    </div>
  </div>
</template>

<script>
import keepsComponent from "../components/keepsComponent";
export default {
  name: "profile",
  mounted(){
     this.$store.dispatch("getProfileBlogs", this.$route.params.profileId);
     this.$store.dispatch("getSearchedProfile", this.$route.params.profileId);
    //NOTE pretty sure its "userId" or "creatorId"
  },
  computed: {
    keeps(){
      return this.$store.state.profileKeeps;
    },
    profile(){
      return this.$store.state.searchedProfile;
    }
  },
  methods: {},
  componenets:
      {keepsComponent}
}
</script>

<style>

</style>