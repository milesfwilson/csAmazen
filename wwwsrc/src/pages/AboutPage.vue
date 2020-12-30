<template>
  <div class="about row my-5">
    <div class="col-1 d-flex justify-content-end">
      <div class="d-flex flex-column">
        <create-option-component :item-props="item" />
        <div v-for="option in options" :key="option.color">
          <div :class="{'selected': state.option === option.id}" class="rounded-circle m-2 grow" :style="'height: 40px; width: 40px;' + 'background-color: ' + option.color + ';'" @click="activeOption(option.id)">
            <button class="btn move-left" @click="deleteOption(option.id)" v-if="profile.id == option.creatorId">
              <i class="fa fa-trash-o" aria-hidden="true"></i>
            </button>
          </div>
        </div>
      </div>
    </div>
    <div class="col-4">
      <div class="row">
        <div class="col-12 d-flex justify-content-center">
          <div :style="'background-image: url('+item.picture+');'" class="bg-img rounded shadow "></div>
        </div>
      </div>

      <div class="row">
        <div class="col-12">
          <form class="form" @submit.prevent="addToList(item.id, state.listId, state.option)">
            <div class="row justify-content-center">
              <select v-model="state.listId"
                      name=""
                      id=""
                      class="m-2 w-75"
                      data-option-label="Select a List"
                      required
              >
                <option disabled value="">
                  Select a List
                </option>
                <option v-for="list in lists" :key="list.id" :value="list.id">
                  {{ list.title }}
                </option>
              </select>
            </div>
            <div class="row justify-content-center">
              <button type="submit" class="btn btn-outline-dark btn-light w-75 m-2 border-dark" v-if="profile.id && state.option">
                Add to Wishlist
              </button>
              <button type="submit" class="btn btn-outline-dark btn-light w-75 m-2 border-dark" v-else disabled>
                Add to Wishlist
              </button>
              <button type="button" class="btn btn-outline-dark btn-light w-75 m-2 border-dark" @click="goToList(state.listId)">
                Go to Wishlist
              </button>
              <p v-if="!profile.id" class="text-danger">
                Please sign in
              </p>
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
            <p v-if="item.salePrice > 0 && item.salePrice < item.price">
              ${{ item.salePrice }}
            </p>
          </div>
        </div>
        <div class="col-4 d-flex justify-content-end">
          <p class="text-center">
            {{ item.quantity }} in stock
          </p>
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
import { itemService } from '../services/ItemService'
import { optionService } from '../services/OptionService'
import { createOptionComponent } from '../components/CreateOptionComponent'
import router from '../router'
export default {
  name: 'About',
  setup() {
    const state = reactive({
      listId: null,
      option: null
    })
    const route = useRoute()
    onMounted(() => {
      listItemService.inList(route.params.itemId)
      itemService.getOne(route.params.itemId)
      optionService.getOptionsByItemId(route.params.itemId)
    })
    return {
      item: computed(() => AppState.activeItem),
      lists: computed(() => AppState.lists),
      profile: computed(() => AppState.profile),
      options: computed(() => AppState.activeOptions),
      state,
      async addToList(itemId, listId, optionId) {
        const newListItem = {
          itemId: itemId,
          listId: listId,
          optionId: optionId
        }

        listItemService.create(newListItem)
        state.option = null
      },
      async inList(itemId) {
        listItemService.inList(itemId)
      },
      async goToList(id) {
        router.push({ name: 'Profile' })
        if (id) {
          listItemService.getActiveListItems(id)
        } else {
          listItemService.showAllListItems(AppState.profile.id)
        }
      },
      async deleteOption(optionId) {
        optionService.deleteOption(optionId)

        const index = AppState.activeOptions.findIndex(o => o.id === optionId)
        AppState.activeOptions.splice(index, 1)
      },
      async activeOption(id) {
        state.option = id
      }
    }
  },
  components: { editItemComponent, createOptionComponent }
}
</script>

<style scoped>
.bg-img {
  width: 20em;
height: 20em;
background-position: center;
background-size: cover;
}

.move-left {
  position: relative;
  right: 25px;
  top: 20px;
}

.selected {
  border: 3px solid white;
 box-shadow: 0 0 10px rgb(27, 27, 27);
}

</style>
