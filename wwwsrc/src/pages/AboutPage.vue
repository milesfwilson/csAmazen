<template>
  <div class="about row">
    <div class="">
      <div class="col-1"></div>
      <div class="col-4">
        <div class="row">
          <div class="col-12">
            <img :src="item.picture" class="img-fluid" alt="">
          </div>
        </div>
        <div class="row">
          <div class="col-12">
            <select name="" id="">
            </select>
          </div>
        </div>
        <div class="row">
          <div class="col-12">
            <form action="" @submit.prevent="addToList(item.id, state.listId)">
              <select v-model="state.listId" name="" id="">
                <option value="" disabled selected>
                  Add to Wishlist
                </option>
                <option v-for="list in lists" :key="list.id" :value="list.id">
                  {{ list.title }}
                </option>
              </select>
              <button type="submit" class="btn btn-primary">
                Add
              </button>
            </form>
          </div>
        </div>
      </div>
      <div class="col-6">
        <div class="">
          <div class="col-12 border">
            <h3 class="text-center">
              {{ item.title }}
            </h3>
          </div>
        </div>
        <div class="row">
          <div class="col-12">
            <p>{{ item.description }}</p>
          </div>
        </div>
        <div class="row">
          <div class="col-4">
            <i class="fa fa-star" aria-hidden="true"></i>
            <i class="fa fa-star" aria-hidden="true"></i>
            <i class="fa fa-star" aria-hidden="true"></i>
            <i class="fa fa-star" aria-hidden="true"></i>
            <i class="fa fa-star" aria-hidden="true"></i>
          </div>
          <div class="col-4">
            <button class="btn btn-primary">
              Edit
            </button>
          </div>
          <div class="col-4">
            ${{ item.price }}
          </div>
        </div>
      </div>
      <div class="col-1"></div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
import { listItemService } from '../services/ListItemService'
export default {
  name: 'About',
  setup() {
    const state = reactive({
      listId: null
    })
    return {
      item: computed(() => AppState.activeItem),
      lists: computed(() => AppState.lists
      ),
      state,
      async addToList(itemId, listId) {
        const newListItem = {
          itemId: itemId,
          listId: listId
        }
        listItemService.create(newListItem)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
