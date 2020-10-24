import Vue from "vue";
import Vuex from "vuex";
import { api } from "../services/AxiosService.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    keeps: [],
    profileKeeps:[],
    searchedProfile: [],
    activeKeep: {}
  },
  mutations: {
    setProfile(state, profile) {
      state.profile = profile;
    },
    setKeeps(state, keeps){
      state.keeps = keeps
    },
    setProfileKeeps(state , keeps){
      state.profileKeeps = keeps
    },
    setSearchedProfile(state , profile){
      state.searchedProfile = profile
    },
    setActiveKeep(state , keep){
      state.activeKeep = keep
    },
  },
  actions: {
    async getProfile({ commit }) {
      try {
        let res = await api.get("profiles");
        commit("setProfile", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async getKeeps({commit , dispatch}){
      try {
        let res = await api.get("keeps")
        commit("setKeeps" , res.data)
      } catch (error) {
        console.error(error)
      }
    } ,
    async getProfileKeeps({commit , dispatch} , profileId){
      //NOTE i feel like its userID
      try {
        let res = await api.get("profiles/" + profileId + "/blogs")
        commit("setProfileKeeps" , res.data)
      } catch (error) {
        console.log(error)
      }
    },
    async getSearchedProfile({commit , dispatch } , profileId){
      try {
        let res = await api.get("profiles/" + profileId)
        commit("setSearchedProfile", res.data)
      } catch (error) {
        console.error(error)
      }
    },
    setActiveKeep({ commit }, keepData) {
      commit("setActiveKeep", keepData)
    },

    async getActiveKeep({commit} , keepId){
      try {
        let res = await api.get('keeps/' + keepId)
        commit('setActiveKeep', res.data)
      } catch (error) {
        console.error(error);
      }
    }

  },
});
