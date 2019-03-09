import Vue from 'vue'
import axios from 'axios'
import router from './router/index'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'
import { FontAwesomeIcon } from './icons'
import VeeValidate from "vee-validate"
import Vuetify from 'vuetify'

// Registration of global components
Vue.component('icon', FontAwesomeIcon)
Vue.use(VeeValidate);
Vue.use(require('vue-moment'))
Vue.use(Vuetify,{
  theme:{
    primary:'#18FFFF',
    secondary:'#546E7A'
  }
})

Vue.prototype.$http = axios

sync(store, router)

const app = new Vue({
  store,
  router,
  ...App
})

export {
  app,
  router,
  store
}
