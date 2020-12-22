import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from '../services/AxiosService'
class ItemService {
  async get() {
    try {
      if (!AppState.profile.id) {
        const res = await api.get('api/item')
        AppState.items = res.data
      } else if (AppState.profile.id) {
        this.getAllItems()
      }
    } catch (error) {
      logger.error(error)
    }
  }

  async getAllItems() {
    try {
      const res = await api.get('profile/' + AppState.profile.id + '/item')
      AppState.items = res.data
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

  async edit(editedItem, id) {
    try {
      await api.put('api/item/' + id, editedItem)
      this.get()
    } catch (error) {
      logger.error(error)
    }
  }

  setActiveItem(item) {
    AppState.activeItem = item
  }
}

export const itemService = new ItemService()
