<template>
  <div class="list-item-component row my-2 border shadow rounded bg-light grow">
    <div class="col-2">
      <router-link :to="{name: 'About', params: {itemId: item.id}}" class="text-dark no-decoration" @click="setActiveItem(item)">
        <div :style="'background-image: url('+item.picture+');'" class="bg-img w-50 m-1">
        </div>
      </router-link>
    </div>
    <div class="col-1 d-flex flex-column justify-content-center">
      <i class="fa fa-circle fa-2x" v-if="item.listItemId" :style="'color:'+showOption(item.listItemId)" aria-hidden="true"></i>
    </div>
    <div class="col-5 d-flex">
      <h4 class="my-auto">
        <router-link :to="{name: 'About', params: {itemId: item.id}}" class="text-dark no-decoration" @click="setActiveItem(item)">
          {{ item.title }}
        </router-link>
      </h4>
    </div>
    <div class="col-2 d-flex justify-content-end" :class="{'col-4': !item.listItemId}">
      <div class="d-flex justify-content-around flex-column">
        <h6 class="my-1" :class="{'strike': item.salePrice < item.price && item.salePrice > 0}">
          ${{ item.price }}
        </h6>
        <h6 class="my-1" v-if="(item.salePrice < item.price) && item.salePrice > 0">
          ${{ item.salePrice }}
        </h6>
      </div>
    </div>
    <div class="col-2 d-flex justify-content-end" v-if="item.listItemId">
      <button class="btn" @click="deleteItem(item.id, item.listItemId)">
        <i class="fa fa-trash-o fa-1x" aria-hidden="true"></i>
      </button>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { listItemService } from '../services/ListItemService'
import { itemService } from '../services/ItemService'
import { AppState } from '../AppState'
export default {
  name: 'ListItemComponent',
  props: ['itemProps'],
  setup(props) {
    return {
      item: computed(() => props.itemProps),
      async deleteItem(itemId, listItemId) {
        listItemService.deletelistItem(itemId, listItemId)
      },
      setActiveItem(item) {
        itemService.setActiveItem(item)
      },
      showOption(listItemId) {
        if (listItemId) {
          const index = AppState.listItems.findIndex(li => li.id === listItemId)
          if (AppState.listItems[index]) {
            const oId = AppState.listItems[index].optionId
            const optionIndex = AppState.options.findIndex(o => o.id === oId)
            return AppState.options[optionIndex].color
          }
        } else {
          return '#000000'
        }
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

.no-decoration {
  text-decoration: none;
}
</style>
