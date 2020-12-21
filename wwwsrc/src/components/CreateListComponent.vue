<template>
  <div class="create-list-component">
    <form action="" @submit.prevent="create(state.newList)">
      <input type="text" placeholder="title" v-model="state.newList.title">
      <button type="submit" class="btn btn-primary">
        Add
      </button>
    </form>
  </div>
</template>

<script>
import { reactive } from 'vue'
import { listService } from '../services/ListService'
export default {
  name: 'CreateListComponent',
  setup() {
    const state = reactive({
      newList: {

      }
    })
    return {
      state,
      create(newList) {
        listService.create(newList)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
