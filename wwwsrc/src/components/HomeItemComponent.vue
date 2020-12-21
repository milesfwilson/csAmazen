<template>
  <div class="home-item-component col-3">
    <router-link :to="{name: 'About', params: {itemId: item.id}}" class="text-dark no-decoration" @click="setActiveItem(item)">
      <div class="shadow rounded border border-dark m-2 p-2">
        <img :src="item.picture" class="img-fluid" alt="">
        <h4>{{ item.title }}</h4>
        <p class="text-center">
          {{ item.description }}
        </p>
        <h6>
          ${{ item.price }}
        </h6>
      </div>
    </router-link>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import { itemService } from '../services/ItemService'
export default {
  name: 'HomeItemComponent',
  props: ['itemProps'],
  setup(props) {
    return {
      item: computed(() => props.itemProps),
      items: computed(() => AppState.items),
      setActiveItem(item) {
        itemService.setActiveItem(item)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
