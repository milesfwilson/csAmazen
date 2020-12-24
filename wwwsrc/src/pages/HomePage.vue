<template>
  <div class="home">
    <div class="col-12">
      <div class="row my-3">
        <div class="col-lg-8 offset-lg-2 col-12">
          <div class="d-flex justify-content-center">
            <input type="text" class="p-1 w-75" placeholder="Search" v-model="state.query.title">
            <button class="btn btn-outline-dark mx-2">
              <i class="fa fa-search" aria-hidden="true"></i>
            </button>

            <create-item-component />
          </div>
        </div>
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
