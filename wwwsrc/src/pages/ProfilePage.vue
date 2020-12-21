<template>
  <div class="about row">
    <create-list-component />
    <list-component v-for="list in lists" :key="list.id" :list-props="list" />
    <div class="col-12">
      <list-item-component v-for="item in items" :key="item.id" :item-props="item" />
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
