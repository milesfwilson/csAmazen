<template>
  <div class="home">
    <div class="col-12">
      <div class="row">
        <div class="col-12">
          <input type="text" v-model="state.query.title" placeholder="Search">
        </div>
      </div>
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
import { computed, reactive, onMounted } from 'vue'
import { AppState } from '../AppState'
import CreateItemComponent from '../components/CreateItemComponent.vue'
import { itemService } from '../services/ItemService'
export default {
  components: { HomeItemComponent, CreateItemComponent },
  name: 'Home',
  setup() {
    const state = reactive({
      query: {
        title: ''
      }
    })
    onMounted(() => {
      itemService.get()
    })

    return {
      state,
      items: computed(() => AppState.items.filter(i => i.title.toUpperCase().includes(state.query.title.toUpperCase()))),
      profile: computed(() => AppState.profile)
    }
  }
}
</script>

<style scoped lang="scss">

</style>
