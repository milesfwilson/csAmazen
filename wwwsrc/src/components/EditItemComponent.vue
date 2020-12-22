<template>
  <div class="edit-item-component">
    <!-- Modal -->
    <button class="btn" data-toggle="modal" :data-target="'#edit'+item.id">
      <i class="fas fa-ellipsis-v"></i>
    </button>

    <div class="modal fade"
         :id="'edit'+item.id"
         tabindex="-1"
         role="dialog"
         aria-labelledby="modelTitleId"
         aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">
              Edit
            </h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form action="" @submit.prevent="edit(state.editedItem, item.id)" class="">
              <div class="row">
                <input class="w-100 p-2 my-1" type="text" placeholder="Title" v-model="state.editedItem.title" required>
              </div>
              <div class="row">
                <input class="w-100 p-2 my-1" type="text" placeholder="Description" v-model="state.editedItem.description" required>
              </div>
              <div class="row">
                <input class="w-100 p-2 my-1" type="text" placeholder="Picture" v-model="state.editedItem.picture" required>
              </div>
              <div class="row">
                <input class="w-100 p-2 my-1"
                       type="number"
                       placeholder="Price"
                       v-model="state.editedItem.price"
                       step="0.01"
                       min="0"
                       required
                >
              </div>
              <div class="row">
                <input class="w-100 p-2 my-1"
                       type="number"
                       placeholder="Sale Price"
                       v-model="state.editedItem.salePrice"
                       step="0.01"
                       min="0"
                >
              </div>
              <div class="row">
                <input class="w-100 p-2 my-1" type="number" placeholder="Quantity" v-model="state.editedItem.quantity" required>
              </div>
              <div class="row">
                <input class="w-100 p-2 my-1" type="number" placeholder="Rating" v-model="state.editedItem.rating" required>
              </div>
              <div class="row">
                <label for="">Publish</label>
                <input class="p-2 m-1" type="checkbox" placeholder="Publish" v-model="state.editedItem.isAvailable">
              </div>
              <div class="row">
                <button type="submit" class="btn btn-primary btn-block">
                  Save
                </button>
              </div>
            </form>

            <button @click="deleteItem(item.id)" class="btn btn-danger btn-block">
              Delete
            </button>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-danger" data-dismiss="modal">
              Close
            </button>
            <button type="button" class="btn btn-primary">
              Save
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { itemService } from '../services/ItemService'
import { AppState } from '../AppState'
export default {
  name: 'EditItemComponent',
  props: ['itemProps'],
  setup(props) {
    const state = reactive({
      editedItem: AppState.activeItem

    })
    return {
      item: computed(() => props.itemProps),
      deleteItem(id) {
        itemService.deleteItem(id)
      },
      edit(editedItem, id) {
        itemService.edit(editedItem, id)
      },
      state
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
