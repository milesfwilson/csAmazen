<template>
  <div class="list-component col-12 col-md-3">
    <div class="shadow rounded btn btn-dark justify-content-between d-flex my-1 list">
      <h3 @click="getActiveListItems(list.id)" class="my-auto">
        {{ list.title }}
      </h3>
      <button class="btn" @click="deleteList(list.id)">
        <i class="fa fa-trash-o my-auto text-light" aria-hidden="true"></i>
      </button>
    </div>
  </div>
</template>

<script>
// import { AppState } from '../AppState'
import { computed } from 'vue'
import { listItemService } from '../services/ListItemService'
import { listService } from '../services/ListService'
export default {
  name: 'ListComponent',
  props: ['listProps'],
  setup(props) {
    return {
      list: computed(() => props.listProps),
      getActiveListItems(listId) {
        listItemService.getActiveListItems(listId)
      },
      deleteList(listId) {
        listService.deleteList(listId)
      }
    }
  },
  components: { }
}
</script>

<style lang="scss" scoped>

</style>
