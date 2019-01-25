<template>
    <div class="box">
        <banner></banner>
        <mainContent></mainContent>
         <wbc-footer></wbc-footer>
    </div>
     
</template>

<script>
import banner from './components/thirdPage/banner.vue'
import mainContent from './components/thirdPage/mainContent.vue'
import relation from './components/thirdPage/relation.vue'
import moocFooter from "./moocFooter.vue"

export default {
    name: 'Video',
    components: {
        banner,
        mainContent,
        'wbc-footer':moocFooter
    }
}
</script>

<style> 
.box {
    width: 100%;
}
</style>