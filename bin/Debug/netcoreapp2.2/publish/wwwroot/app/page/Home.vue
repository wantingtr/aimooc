<template>
    <div>
        <wbc-nav></wbc-nav>
        <div id="contentBox">
            <wbc-content></wbc-content>
        </div>
        
            <wbc-footer></wbc-footer>

    </div>
</template>

<script>
import header from "./components/firstPage/initialHeader.vue"
import content from "./components/firstPage/initialContent.vue"
import moocFooter from "./moocFooter.vue"

export default {

        components: { //定义组件
        'wbc-nav':header,
        'wbc-content':content,
        'wbc-footer':moocFooter
    },
}
</script>


<style scoped>
#contentBox{
    width: 100%;
}
</style>
