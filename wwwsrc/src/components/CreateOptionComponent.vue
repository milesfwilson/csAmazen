<template>
  <div class="create-option-component">
    <!-- Button trigger modal -->

    <button class="btn" v-if="profile.id == item.creatorId" data-toggle="modal" data-target="#createOption">
      <i class="fa fa-plus-circle fa-2x text-dark mx-auto my-1" aria-hidden="true"></i>
    </button>

    <!-- Modal -->
    <div class="modal fade"
         id="createOption"
         tabindex="-1"
         role="dialog"
         aria-labelledby="modelTitleId"
         aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title">
              Create Option
            </h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div class="modal-body">
            <form class="form d-flex justify-content-center" @submit.prevent="create(item.id, state.newOption)">
              <input type="text" v-model="state.newOption.color" placeholder="Select a Color" required>

              <button type="submit" class="btn btn-primary">
                Submit
              </button>
            </form>
          </div>
          <div class="modal-footer">
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
import { optionService } from '../services/OptionService'
import $ from 'jquery'
export default {
  name: 'CreateOptionComponent',
  props: ['itemProps'],
  setup(props) {
    const state = reactive({
      newOption: {

      }
    })
    return {
      item: computed(() => props.itemProps),
      profile: computed(() => AppState.profile),
      state,
      create(id, newOption) {
        newOption.itemId = id
        optionService.create(newOption)
        $('#createOption').modal('hide')
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
