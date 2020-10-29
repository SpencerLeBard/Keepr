import Vue from "vue";
import Vuex from "vuex";
import { api } from "../services/AxiosService.js";
import ns from "../services/NotificationServices";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    profile: {},
    keeps: [],
    vaults: [],
    vaultkeeps: [] , 
    profileKeeps:[],
    searchedProfile: {},
    activeKeep: {} ,
    activeVault: {},
    activeVaultKeeps: [],
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
    setActiveVault(state , vault){
      state.activeVault = vault
    },
    addKeep(state , keep){
      state.keeps = keep
    },
    addVault(state , vault){
      state.vaults = vault
    },
    addVaultKeep(state , vaultkeep){
      state.vaultkeeps = vaultkeep
    },
    deleteVaultKeep(state , vaultkeep){
      state.vaultkeeps = vaultkeep
    },
    keepViewCount(state , keep){
      state.keeps = keep
    },
    activeVaultKeeps(state , vaultkeeps){
      state.activeVaultKeeps = vaultkeeps
    },
    // clearActiveKeep(state , {empty}){
    //   state.activeKeep = {empty}
    //   // debugger
    // }
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
    // async getKeepsByCreatorId({commit , dispatch} , profileId){
    //   try {
    //     let res = await api.get("profiles/" + profileId + "/keeps")
    //     commit("setKeeps" , res.data)
    //   } catch (error) {
    //     console.error(error)
    //   }
    // } ,
    async getVaultsByProfile({commit , dispatch} , profileId){
      // debugger
      try {
        let res = await api.get("profiles/" + profileId + "/vaults")
        commit("setVaults" , res.data)
        commit("setActiveVault" , res.data)
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
    // async getActiveVault({commit , dispatch} , profileId){
    //   try {
    //     let res = await api.get("profiles/" + profileId + "/vaults")
    //     commit("setActiveVault" , res.data)
    //   } catch (error) {
    //     console.log(error)
    //   }
    // },
    async getSearchedProfile({commit , dispatch } , profileId){
      try {
        let res = await api.get("profiles/" + profileId)
        commit("setSearchedProfile", res.data)
        // @ts-ignore
        $("#keepModal").hide()
        // @ts-ignore
        $(".modal-backdrop").hide()
      } catch (error) {
        console.error(error)
      }
    },
    async setActiveKeep({ commit }, keepData) {
      try{
      let res = await api.get('keeps/' + keepData.id)
      commit("setActiveKeep", keepData)
      } catch (error){
        console.error(error);
      }
    },
    async setActiveVault({ commit }, vaultData) {
      try{
      let res = await api.get('vaults/' + vaultData.id)
      commit("setActiveVault", vaultData)
      commit("getKeepsByVaultId" , res.data)
      } catch (error){
        console.error(error);
      }
    },
    async createKeep({ commit, dispatch }, keepData) {
      try {
        let res = await api.post("keeps", keepData)
        commit("addKeep" )
        dispatch("getKeeps")
      } catch (error) {
        console.error(error)
      }
    },
    async deleteKeep({ commit, dispatch }, keepId) {
      try {
        if (await ns.confirmAction("Do you want to delete this board?", "You'll never get it back ...")) {
        await api.delete("keeps/" + keepId)
        dispatch("getKeeps")
      }} catch (error) {
        console.error(error)

      }
    },
    async createVault({ commit, dispatch }, vaultData) {
      try {
        let res = await api.post("vaults", vaultData)
        commit("addVault" )
        dispatch("getVaults")
      } catch (error) {
        console.error(error)
      }
    },
    async createVaultKeep({ commit, dispatch }, vaultKeepData) {
      try {
        let res = await api.post("vaultkeeps", vaultKeepData)
        commit("addVaultKeep")
      } catch (error) {
        console.error(error)
      }
    },
    async deleteVaultKeep({ commit, dispatch }, vaultKeepData) {
      try {
        if (await ns.confirmAction("Do you want to delete this board?", "You'll never get it back ...")) {
        let res = await api.delete("vaultkeeps/" + vaultKeepData , vaultKeepData)
        commit("deleteVaultKeep" , vaultKeepData)
      }} catch (error) {
        console.error(error)
      }
    },
    async deleteVault({ commit, dispatch }, vaultId) {
      try {
        if (await ns.confirmAction("Do you want to delete this board?", "You'll never get it back ...")) {
        await api.delete("vaults/" + vaultId)
        dispatch("getVaults")
      }} catch (error) {
        console.error(error)

      }
    },
    async getKeepsByVaultId({commit , dispatch} , vaultData){
      try {
        let res = await api.get("vaults/" + vaultData + "/keeps")
        commit("activeVaultKeeps" , res.data)
      } catch (error) {
        console.log(error)
      }
    },
    async keepViewsCount({commit , dispatch} , keepData){
      try{
        let res = await api.put("keeps/" + keepData.id , keepData)
        commit("setActiveKeep", res.data)
      // dispatch("keepViewCount" , keepData.id)
      } catch(error){
        console.error(error);
      }
    },
    async keepsCount({commit , dispatch} , keepData){
      try{
        let res = await api.put("keeps/" + keepData.id + "/keepscount", keepData)
        commit("setActiveKeep", res.data)
      } catch(error){
        console.error(error);
      }
    },
  }
});
