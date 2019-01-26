<template>
    <div class="box">
        <banner></banner>
        <mainContent></mainContent>
         <wbc-footer></wbc-footer>
    </div>
     
</template>


<script lang="ts">
import Vue from 'vue'
import banner from './components/thirdPage/banner.vue'
import mainContent from './components/thirdPage/mainContent.vue'
import moocFooter from "./moocFooter.vue"
export default Vue.extend({
    name: 'Video',
    components: {
        banner,
        mainContent,
        'wbc-footer':moocFooter
    }    
})
</script>

<style> 
.box {
    width: 100%;
}
</style>