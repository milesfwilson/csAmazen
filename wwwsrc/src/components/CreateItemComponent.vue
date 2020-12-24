<template>
  <div class="create-item-component">
    <button class="btn btn-outline-primary"
            type="button"
            data-toggle="modal"
            data-target="#modalCreateItem"
    >
      New Item
    </button>

    <div class="modal fade"
         id="modalCreateItem"
         tabindex="-1"
         role="dialog"
         aria-labelledby="modelTitleId"
         aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">
              Create New Item
            </h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form action="" @submit.prevent="create(state.newItem)" class="p-2">
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
        </div>
      </div>
    </div>
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
