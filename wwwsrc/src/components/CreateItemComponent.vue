<template>
  <div class="create-item-component col-8 offset-2">
    <form action="" @submit.prevent="create(state.newItem)" class="">
      <div class="row">
        <input class="w-100 p-2 my-1" type="text" placeholder="Title" v-model="state.newItem.title" required>
      </div>
      <div class="row">
        <input class="w-100 p-2 my-1" type="text" placeholder="Description" v-model="state.newItem.description" required>
      </div>
      <div class="row">
        <input class="w-100 p-2 my-1" type="text" placeholder="Picture" v-model="state.newItem.picture" required>
      </div>
      <div class="row">
        <input class="w-100 p-2 my-1"
               type="number"
               placeholder="Price"
               v-model="state.newItem.price"
               step="0.01"
               min="0"
               required
        >
      </div>
      <div class="row">
        <input class="w-100 p-2 my-1"
               type="number"
               placeholder="Sale Price"
               v-model="state.newItem.salePrice"
               step="0.01"
               min="0"
        >
      </div>
      <div class="row">
        <input class="w-100 p-2 my-1" type="number" placeholder="Quantity" v-model="state.newItem.quantity" required>
      </div>
      <div class="row">
        <input class="w-100 p-2 my-1" type="number" placeholder="Rating" v-model="state.newItem.rating" required>
      </div>
      <div class="row">
        <label for="">Publish</label>
        <input class="p-2 m-1" type="checkbox" placeholder="Publish" v-model="state.newItem.isAvailable">
      </div>
      <div class="row">
        <button type="submit" class="btn btn-primary btn-block">
          Submit
        </button>
      </div>
    </form>
  </div>
</template>

<script>
import { reactive } from 'vue'
import { itemService } from '../services/ItemService'
export default {
  name: 'CreateItemComponent',
  setup() {
    const state = reactive({
      newItem: {

      }
    })
    return {
      state,
      create(newItem) {
        itemService.create(newItem)
        state.newItem = {}
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
