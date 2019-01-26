import Vue from 'vue'
import Router from 'vue-router'
import Home from '../page/Home.vue'
import Video from '../page/Video.vue'

// Vue.use(Router)

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      component: Home
    },
    {
      path: '/video',
      component: Video
    }
  ]
})
