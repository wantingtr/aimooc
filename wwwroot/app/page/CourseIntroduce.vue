<template>
    <div>
        <sec-header></sec-header>
        <sec-content></sec-content>
    </div>
</template>


<script lang="ts">
import Vue from 'vue'
import secondHeader from './components/secondPage/secondHeader.vue'
import secondContent from './components/secondPage/secondContent.vue'
export default Vue.extend({
    components:{
        "sec-header":secondHeader,
        "sec-content":secondContent,
    }   
})
</script>

<style scoped>

</style>


