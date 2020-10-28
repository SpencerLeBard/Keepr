<template>
  <div class="vault-page container-fluid">
    <div class="row">
      <h1> Vault Name:{{activeVault.name}} </h1>
    </div>
    <div class="row">
    <h1>Keeps in Vault:</h1>
    </div>
    <div class="row">
    <keeps-component v-for="keep in keeps" :key="keep.id" :keepProp="keep" />
    </div>
  </div>
</template>

<script>
import keepsComponent from "../components/keepsComponent"
export default {
  name: "vault-page" ,
  mounted(){
    this.$store.dispatch("getKeepsByVaultId" , this.$route.params.vaultId)
    this.$store.dispatch("getActiveVault" , this.$route.params.vaultId)

  },
  data() {
    return {}
    },
  computed: {
    keeps(){
      return this.$store.state.keeps
    },
    activeVault(){
      return this.$store.state.activeVault
    },
    activeVaultKeeps(){
      return this.$store.state.activeVaultKeeps
    }
      },
    components: {
      keepsComponent ,
    }
}
</script>

<style>

</style>