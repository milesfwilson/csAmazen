<template>
  <div class="about">
    <list-component v-for="list in lists" :key="list.id" :list-props="list" />
  </div>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../AppState'
import ListComponent from '../components/ListComponent.vue'
export default {
  components: { ListComponent },
  name: 'Profile',
  setup() {
    return {
      profile: computed(() => AppState.profile),
      lists: computed(() => AppState.lists)
    }
  }
}
</script>

<style scoped>
img {
  max-width: 100px;
}
</style>
