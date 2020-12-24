<template>
  <div class="about col-12">
    <div class="row">
      <create-list-component />
    </div>
    <div class="row">
      <div class="col-4">
        <div class="shadow rounded p-2 m-2 bg-light justify-content-between d-flex">
          <h3 @click="showAllListItems(profile.id)" class="my-auto">
            All
          </h3>
          <button class="btn" @click="deleteList(list.id)" disabled>
            <i class="fa fa-trash-o my-auto text-light" aria-hidden="true"></i>
          </button>
        </div>
      </div>
      <list-component v-for="list in lists" :key="list.id" :list-props="list" />
    </div>
    <div class="row">
      <div class="col-1"></div>
      <div class="col-10 d-flex justify-content-end">
        <div>
          <h6>
            Your total:
          </h6>
          <h4 class="strike">
            ${{ total(items) }}
          </h4>
          <h4>
            ${{ totalSale(items) }}
          </h4>
        </div>
      </div>
      <div class="col-1"></div>
    </div>
    <div class="row">
      <div class="col-10 offset-1">
        <list-item-component v-for="item in items" :key="item.id" :item-props="item" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import ListComponent from '../components/ListComponent.vue'
import ListItemComponent from '../components/ListItemComponent.vue'
import createListComponent from '../components/CreateListComponent.vue'
import { listItemService } from '../services/ListItemService'
export default {
  components: { ListComponent, ListItemComponent, createListComponent },
  name: 'Profile',
  setup() {
    return {
      profile: computed(() => AppState.profile),
      lists: computed(() => AppState.lists),
      items: computed(() => AppState.activeListItems),
      allListItems: computed(() => AppState.allMyItems),
      showAllListItems(profileId) {
        listItemService.showAllListItems(profileId)
      },
      total(items) {
        let total = 0

        items.forEach(i => {
          total += i.price
        })
        return total
      },
      totalSale(items) {
        let total = 0

        items.forEach(i => {
          total += i.salePrice
        })
        return total
      }
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
