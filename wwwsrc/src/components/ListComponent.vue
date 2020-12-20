<template>
  <div class="list-component">
    {{ list.title }}
  </div>
</template>

<script>
// import { AppState } from '../AppState'
import { computed } from 'vue'
export default {
  name: 'ListComponent',
  props: ['listProps'],
  setup(props) {
    return {
      list: computed(() => props.listProps)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
