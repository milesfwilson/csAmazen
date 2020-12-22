<template>
  <div class="home">
    <div class="col-12">
      <div class="row" v-if="profile.id">
        <div class="col-12 d-flex justify-content-center">
          <button class="btn btn-primary m-2"
                  type="button"
                  data-toggle="collapse"
                  data-target="#createCollapse"
                  aria-expanded="false"
                  aria-controls="contentId"
          >
            Add New Item
          </button>
        </div>
      </div>
      <div class="row collapse" id="createCollapse">
        <create-item-component />
      </div>
      <div class="row">
        <home-item-component v-for="item in items" :key="item.id" :item-props="item" />
      </div>
    </div>
  </div>
</template>

<script>
import HomeItemComponent from '../components/HomeItemComponent.vue'
import { computed } from 'vue'
import { AppState } from '../AppState'
import CreateItemComponent from '../components/CreateItemComponent.vue'
export default {
  components: { HomeItemComponent, CreateItemComponent },
  name: 'Home',
  setup() {
    return {
      items: computed(() => AppState.items),
      profile: computed(() => AppState.profile)
    }
  }
}
</script>

<style scoped lang="scss">

</style>
