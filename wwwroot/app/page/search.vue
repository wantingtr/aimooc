<template>
    <div class="box">
        <banner></banner>
        <search-result></search-result>
        <mooc-footer></mooc-footer>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
import banner from './components/thirdPage/banner.vue'
import searchResult from './components/search/searchResult.vue'
import moocFooter from "./moocFooter.vue"
export default Vue.extend({
    name:'search',
    components: {
        'banner': banner,
        'searchResult': searchResult,
        'moocFooter': moocFooter
    }
})
</script>

<style scoped>
.box {
    width: 100%;
}
</style>


