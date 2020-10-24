import Vue from "vue";
import Vuex from "vuex";
import { api } from "../services/AxiosService.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    keeps: [],
    profileKeeps:[],
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
        console.log(res);
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

  },
});
