<template>
  <div class="home">
    <div class="row">
      <home-item-component v-for="item in items" :key="item.id" :item-props="item" />
    </div>
  </div>
</template>

<script>
import HomeItemComponent from '../components/HomeItemComponent.vue'
import { computed } from 'vue'
import { AppState } from '../AppState'
export default {
  components: { HomeItemComponent },
  name: 'Home',
  setup() {
    return {
      items: computed(() => AppState.items)
    }
  }
}
</script>

<style scoped lang="scss">

</style>
