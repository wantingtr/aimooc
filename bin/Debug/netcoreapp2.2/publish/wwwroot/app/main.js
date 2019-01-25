import Vue from 'vue'
import App from './App.vue'
import router from './route/'

import './assets/js/font.js'
import './assets/css/style.css'



Vue.config.productionTip = false



/* eslint-disable no-new */
new Vue({
  el: '#app',
  router,
  components: { App },
  template: '<div><router-view></router-view></div>'
})


