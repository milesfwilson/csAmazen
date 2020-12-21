<template>
  <div class="list-item-component row">
    <div class="col-2">
      <img :src="item.picture" class="img-fluid" alt="">
    </div>
    <div class="col-8">
      {{ item.title }}
    </div>
    <div class="col-2">
      {{ item.price }}
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
export default {
  name: 'ListItemComponent',
  props: ['itemProps'],
  setup(props) {
    return {
      item: computed(() => props.itemProps)
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
