<template>
  <div class="list-component col-4">
    <div class="shadow rounded p-2 m-2">
      <h3 @click="getActiveListItems(list.id)">
        {{ list.title }}
      </h3>
    </div>
  </div>
</template>

<script>
// import { AppState } from '../AppState'
import { computed } from 'vue'
import { listItemService } from '../services/ListItemService'
export default {
  name: 'ListComponent',
  props: ['listProps'],
  setup(props) {
    return {
      list: computed(() => props.listProps),
      getActiveListItems(listId) {
        listItemService.getActiveListItems(listId)
      }
    }
  },
  components: { }
}
</script>

<style lang="scss" scoped>

</style>
