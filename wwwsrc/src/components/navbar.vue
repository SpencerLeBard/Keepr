<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <h1 class="border border-primary">Keepr</h1>
      </div>
    </router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <li @click="viewProfile()"
                class="nav-item"
                v-if="$auth.isAuthenticated"
                :class="{ active: $route.name == 'Profile' }"
              >
                <router-link
                  class="nav-link text-dark"
                  :to="{ name: 'Profile' }"
                >Profile</router-link>
              </li>
      <span class="navbar-text">
        <!-- Consider changing this to a profile picture -->
        <button
          class="btn btn-success"
          @click="login"
          v-if="!$auth.isAuthenticated"
        >
          Login
        </button>
        <button class="btn btn-danger" @click="logout" v-else>logout</button>
      </span>
    </div>
  </nav>
</template>

<script>
import { getUserData } from "@bcwdev/auth0-vue";
import { setBearer, resetBearer } from "../services/AxiosService";
import {ProfilePage} from "../pages/ProfilePage"
export default {
  name: "Navbar",
   mounted(){
     this.$store.dispatch("getProfile");
    this.$store.dispatch("getSearchedProfile", this.$route.params.profileId);
    this.$store.dispatch("getVaultsByProfile" , this.$route.params.profileId)
     this.$store.dispatch("getProfileKeeps", this.$route.params.profileId);
     this.$store.dispatch("getKeepsByCreatorId", this.$route.params.profileId);
  },
  methods: {
    async login() {
      await this.$auth.loginWithPopup();
      if (this.$auth.isAuthenticated) {
        setBearer(this.$auth.bearer);
        this.$store.dispatch("getProfile");
      }
    },
    async logout() {
      resetBearer();
      await this.$auth.logout({ returnTo: window.location.origin });
    },
    viewProfile(){
      this.$router.push({name: "Profile", params: { profileId:this.profile}})
      this.$store.dispatch("getSearchedProfile" , this.profile.id)
  },

     },
   computed:{
    profile(){
      return this.$store.state.profile
    },
    vaults(){
      return this.$store.state.vaults
    },
    keeps(){
      return this.$store.state.profileKeeps;
    },
    searchedProfile(){
      return this.$store.state.searchedProfile
    },
   }
}
</script>

<style></style>
