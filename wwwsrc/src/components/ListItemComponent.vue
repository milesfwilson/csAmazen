<template>
  <div class="list-item-component row my-2 border shadow rounded bg-light">
    <div class="col-2">
      <div :style="'background-image: url('+item.picture+');'" class="bg-img w-50 m-1">
      </div>
    </div>
    <div class="col-6 d-flex">
      <h4 class="my-auto">
        {{ item.title }}
      </h4>
    </div>
    <div class="col-2 d-flex justify-content-around flex-column">
      <h6 class="my-1" :class="{'strike': item.salePrice < item.price && item.salePrice > 0}">
        ${{ item.price }}
      </h6>
      <h6 class="my-1" v-if="(item.salePrice < item.price) && item.salePrice > 0">
        ${{ item.salePrice }}
      </h6>
    </div>
    <div class="col-2 d-flex justify-content-end">
      <button class="btn" @click="deleteItem(item.id, item.listItemId)">
        <i class="fa fa-trash-o fa-2x" aria-hidden="true"></i>
      </button>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { listItemService } from '../services/ListItemService'
export default {
  name: 'ListItemComponent',
  props: ['itemProps'],
  setup(props) {
    return {
      item: computed(() => props.itemProps),
      async deleteItem(itemId, listItemId) {
        listItemService.deletelistItem(itemId, listItemId)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.bg-img {
  height: 10vh;
  background-position: center;
  background-size: cover;
}
</style>
