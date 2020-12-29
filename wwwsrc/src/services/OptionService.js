import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'
class OptionService {
  async get() {
    try {
      const res = await api.get('api/option')
      AppState.options = res.data
      logger.log(AppState.options)
    } catch (error) {
      logger.error(error)
    }
  }

  async getOptionsByItemId(itemId) {
    try {
      const res = await api.get('api/item/' + itemId + '/option')
      AppState.activeOptions = res.data
      logger.log(AppState.activeOptions)
    } catch (error) {
      logger.error(error)
    }
  }

  async create(newOption) {
    try {
      await api.post('api/option', newOption)
      this.get()
      this.getOptionsByItemId(newOption.itemId)
    } catch (error) {
      logger.error(error)
    }
  }

  async deleteOption(id) {
    try {
      await api.delete('api/option/' + id)
      this.get()
    } catch (error) {
      logger.error(error)
    }
  }

  async edit(id, editedOption) {
    try {
      await api.put('api/option/' + id, editedOption)
      this.get()
    } catch (error) {
      logger.error(error)
    }
  }
}

export const optionService = new OptionService()
