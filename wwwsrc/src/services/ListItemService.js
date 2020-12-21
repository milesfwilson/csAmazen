import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from '../services/AxiosService'
class ListItemService {
  async get() {
    try {
      const res = await api.get('api/listItem')
      AppState.listItems = res.data
      logger.log(AppState.listItems)
    } catch (error) {
      logger.error(error)
    }
  }

  async getActiveListItems(listId) {
    try {
      const res = await api.get('api/list/' + listId + '/listitem')
      AppState.activeListItems = res.data
    } catch (error) {
      logger.error(error)
    }
  }

  async create(newlistItem) {
    try {
      await api.post('api/listItem', newlistItem)
      this.get()
    } catch (error) {
      logger.error(error)
    }
  }

  async deletelistItem(id) {
    try {
      await api.delete('api/listItem/' + id)
      this.get()
    } catch (error) {
      logger.error(error)
    }
  }

  async edit(id, editedlistItem) {
    try {
      await api.put('api/listItem/' + id, editedlistItem)
      this.get()
    } catch (error) {
      logger.error(error)
    }
  }
}

export const listItemService = new ListItemService()
