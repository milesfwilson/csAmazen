import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from '../services/AxiosService'
class ListService {
  async get() {
    try {
      const res = await api.get('api/list')
      AppState.lists = res.data
      logger.log(AppState.lists)
    } catch (error) {
      logger.error(error)
    }
  }

  async create(newList) {
    try {
      await api.post('api/list', newList)
      this.get()
    } catch (error) {
      logger.error(error)
    }
  }

  async deleteList(id) {
    try {
      await api.delete('api/list/' + id)
      this.get()
    } catch (error) {
      logger.error(error)
    }
  }

  async edit(id, editedList) {
    try {
      await api.put('api/list/' + id, editedList)
      this.get()
    } catch (error) {
      logger.error(error)
    }
  }
}

export const listService = new ListService()
