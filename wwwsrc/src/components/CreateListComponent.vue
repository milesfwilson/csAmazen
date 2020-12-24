<template>
  <div class="create-list-component col-md-8 offset-md-2 col-12">
    <form action="" @submit.prevent="create(state.newList)" class="my-2 d-flex justify-content-center">
      <input type="text" placeholder="Title" v-model="state.newList.title" class="w-75" required>
      <button type="submit" class="btn btn-outline-primary mx-2">
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
        state.newList = {}
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
