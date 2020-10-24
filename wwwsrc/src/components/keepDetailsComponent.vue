<template>
   <div id="keep-details">
    <div class="card" v-if="keep.id">
      <img
        class="card-img-top"
        :src="'https://image.tmdb.org/t/p/w500'+ keep.name"
        alt="keep"
      />
      <div class="card-body">
        <h5 class="card-title">{{keep.name}}</h5>
        <p>{{keep.description}} </p>
        <button>Add to Vault</button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "keep-details",
  computed: {
    keep() {
      return this.$store.state.activeKeep
    }
  }
}
</script>

<style>

</style>