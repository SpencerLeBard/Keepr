import Vue from "vue";
import Vuex from "vuex";
import { api } from "../services/AxiosService.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    keeps: [],
    vaults: [],
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
    setVaults(state, vaults){
      state.vaults = vaults
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
    addKeep(state , keep){
      state.keeps = keep
    }
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
    async getVaults({commit , dispatch} , vaultData){
      try {
        let res = await api.get("vaults/" + vaultData)
        commit("setVaults" , res.data)
      } catch (error) {
        console.error(error)
      }
    } ,
    async getProfileKeeps({commit , dispatch} , profileId){
      try {
        let res = await api.get("profiles/" + profileId + "/keeps")
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
    },
    // count({commit} , keepData){
    //   try {
    //     let res = await api.put('keeps/' + keepId)
    //     commit('setActiveKeep', res.data)
    //   } catch (error) {
    //     console.error(error);
    //   }
    // }
    async createKeep({ commit, dispatch }, keepData) {
      try {
        let res = await api.post("keeps", keepData)
        // console.log(res);
        commit("addKeep" )
        dispatch("getKeeps")
      } catch (error) {
        console.error(error)
      }
    },
  },
});
