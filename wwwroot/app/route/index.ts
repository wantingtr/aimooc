import Vue from 'vue'
import Router from 'vue-router'
import Home from '../page/Home.vue'
import Video from '../page/Video.vue'
import login from '../page/components/login.vue'
import signout from '../page/components/signout.vue'
import search from '../page/search.vue'
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
    },
    {
      path: '/login',
      component: login
    },
    {
      path: '/signout',
      component: signout
    },
    {
      path: '/search',
      component: search
    }
  ]
})
