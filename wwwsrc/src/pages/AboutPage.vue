<template>
  <div class="about row my-5">
    <div class="col-1"></div>
    <div class="col-4">
      <div class="row">
        <div class="col-12 d-flex justify-content-center">
          <div :style="'background-image: url('+item.picture+');'" class="bg-img rounded shadow"></div>
        </div>
      </div>

      <div class="row">
        <div class="col-12">
          <form class="form" @submit.prevent="addToList(item.id, state.listId)">
            <div class="row justify-content-center">
              <select v-model="state.listId" name="" id="" class="m-2 w-75" required>
                <option v-for="list in lists" :key="list.id" :value="list.id">
                  {{ list.title }}
                </option>
              </select>
            </div>
            <div class="row justify-content-center">
              <button type="submit" class="btn btn-outline-dark btn-light w-75 m-2 border-dark">
                Add to Wishlist
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
    <div class="col-6 border bg-light rounded shadow d-flex flex-column justify-content-between">
      <div class="row bg-dark text-light py-2">
        <div class="col-12">
          <h2 class="text-center">
            {{ item.title }}
          </h2>
        </div>
      </div>
      <div class="row">
        <div class="col-12">
          <p class="p-3">
            {{ item.description }}
          </p>
        </div>
      </div>
      <div class="row">
        <div class="col-4">
          <div>
            <i class="fa fa-star text-warning" aria-hidden="true" v-for="star in item.rating" :key="star.length"></i>
          </div>
        </div>

        <div class="col-4">
          <div class="d-flex justify-content-around">
            <p :class="{'strike': item.salePrice && item.salePrice < item.price}">
              ${{ item.price }}
            </p>
            <p v-if="item.salePrice > 0">
              ${{ item.salePrice }}
            </p>
          </div>
        </div>
        <div class="col-4 d-flex justify-content-end">
          <edit-item-component :item-props="item" v-if="profile.id === item.creatorId" />
        </div>
      </div>
    </div>
    <div class="col-1"></div>
  </div>
</template>

<script>
import { computed, reactive, onMounted } from 'vue'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
import { listItemService } from '../services/ListItemService'
import { editItemComponent } from '../components/EditItemComponent'
export default {
  name: 'About',
  setup() {
    const state = reactive({
      listId: null
    })
    const route = useRoute()
    onMounted(() => {
      listItemService.inList(route.params.itemId)
    })
    return {
      item: computed(() => AppState.activeItem),
      lists: computed(() => AppState.lists),
      profile: computed(() => AppState.profile),
      state,
      async addToList(itemId, listId) {
        const newListItem = {
          itemId: itemId,
          listId: listId
        }
        listItemService.create(newListItem)
      },
      async inList(itemId) {
        listItemService.inList(itemId)
      }
    }
  },
  components: { editItemComponent }
}
</script>

<style lang="scss" scoped>
.bg-img {
  width: 20em;
height: 20em;
background-position: center;
background-size: cover;
}
</style>
