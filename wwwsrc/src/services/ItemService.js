import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from '../services/AxiosService'
class ItemService {
  async get() {
    try {
      const res = await api.get('api/item')
      AppState.items = res.data
      logger.log(AppState.items)
    } catch (error) {
      logger.error(error)
    }
  }

  async create(newItem) {
    try {
      await api.post('api/item', newItem)
      this.get()
    } catch (error) {
      logger.error(error)
    }
  }

  async deleteItem(id) {
    try {
      await api.delete('api/item/' + id)
      this.get()
    } catch (error) {
      logger.error(error)
    }
  }

  async edit(id, editedItem) {
    try {
      await api.put('api/item/' + id, editedItem)
      this.get()
    } catch (error) {
      logger.error(error)
    }
  }
}

export const itemService = new ItemService()
