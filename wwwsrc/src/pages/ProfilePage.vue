<template>
  <div class="about col-12">
    <div class="row">
      <create-list-component />
    </div>
    <div class="row">
      <list-component v-for="list in lists" :key="list.id" :list-props="list" />
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
export default {
  components: { ListComponent, ListItemComponent, createListComponent },
  name: 'Profile',
  setup() {
    return {
      profile: computed(() => AppState.profile),
      lists: computed(() => AppState.lists),
      items: computed(() => AppState.activeListItems)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
