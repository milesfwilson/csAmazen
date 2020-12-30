<template>
  <div class="home-item-component col-lg-3 col-md-4 col-6 my-2">
    <router-link :to="{name: 'About', params: {itemId: item.id}}" class="text-dark no-decoration" @click="setActiveItem(item)">
      <div class="shadow rounded border bg-light p-1 grow">
        <div :style="'background-image: url('+item.picture+')'" class="bg-img d-flex justify-content-center">
          <div class="text-center align-self-center">
            <h3 v-if="item.quantity < 1" class="text-danger">
              OUT OF STOCK
            </h3>
            <h3 v-if="!item.isAvailable" class="text-danger">
              DRAFT
            </h3>
          </div>
        </div>

        <h4>{{ item.title }}</h4>
        <div class="my-2">
          <i class="fa fa-star text-warning" aria-hidden="true" v-for="star in item.rating" :key="star.length"></i>
        </div>
        <div class="d-flex justify-content-around">
          <h4 :class="{'strike': item.salePrice && item.salePrice < item.price}">
            ${{ item.price }}
          </h4>
          <h4 v-if="item.salePrice > 0 && item.salePrice < item.price">
            ${{ item.salePrice }}
          </h4>
        </div>
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

<style scoped>
.bg-img {
height: 30vh;
background-size: cover;
background-position: center;
}

.no-decoration {
  text-decoration: none;
}

</style>
