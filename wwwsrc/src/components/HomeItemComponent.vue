<template>
  <div class="home-item-component col-3">
    <div class="shadow rounded border border-dark m-3 p-2 w-100">
      <img :src="item.picture" class="img-fluid" alt="">
      <h4>{{ item.title }}</h4>
      <h6>
        ${{ item.price }}
      </h6>
    </div>
  </div>
</template>

<script>
import { computed } from 'vue'
export default {
  name: 'HomeItemComponent',
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
