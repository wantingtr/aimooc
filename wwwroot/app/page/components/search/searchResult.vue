<template>
    <div class="searchPage">
        <div class="flow">
            <img v-on:click="jumpHome" src="../../../static/img/home.png" class="logo">
            <div class="flow-text" v-on:click="jumpHome">
                相关课程
            </div>
            <img src="../../../static/img/next.png" class="flow-logo">
            <img src="../../../static/img/video.png" class="logo1">
            <div class="flow-text1">
                    {{info.result}}
            </div>
        </div>
        <div class="searchResult" v-for="(info, index) of resultList" :key="index">
            <p class="typeName" >{{info.typeName}}</p>
            <div class="resultPart">
                <div v-for="(item, index) in info.courseList" :key = index class="course-item" v-on:click="jumpVideo(item.courseID)">
                    <div class="courseName">
                        {{item.courseName}}
                    </div>
                    <div class="crossLine"></div>
                    <div class="courseInfo">
                        <img src="../../../static/img/time.png" class="r-logo">
                        <div class="course">
                            {{item.courseTime}}
                        </div>
                        <img src="../../../static/img/beginner.png" class="r-logo">
                        <div class="course">
                            {{item.courseLevel}}
                        </div>
                    </div>
                </div>
            </div>
            <div class="line"></div> 
        </div>
    </div>
</template>

<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
    name: 'searchResult',
    data() {
        return {
            //搜索信息
            info: {
                result: '开发搜索结果'
            },
            //模拟搜索结果
            resultList: [
                {
                    typeName: 'AI开发',
                    courseList: [
                        {
                            courseName:'人工智能开发介绍',
                            courseTime: '1小时45分钟',
                            courseLevel: '初学者'
                        }
                    ]
                },
                {
                    typeName: 'VUE开发',
                    courseList: [
                        {
                            courseName:'VUE开发介绍',
                            courseTime: '1小时45分钟',
                            courseLevel: '初学者'
                        },
                        {
                            courseName:'VUE开发介绍',
                            courseTime: '1小时45分钟',
                            courseLevel: '初学者'
                        }
                    ]
                },
            ]
        }
    },
    methods: {
        jumpHome() {
            this.$router.push({path: "/"});
        },
    }
})
</script>

<style scoped>
.searchPage{
    width: 62.5%;
    margin: 0 auto;
    overflow: hidden;
}
.flow{
    position: relative;
    text-align: left;
    margin-top: .42rem;
    margin-bottom: 0.52rem;  
}
.logo{
    display: inline-block;
    width: .18rem;
    vertical-align: middle;
}
.logo1{
    display: inline-block;
    width: .18rem;
    vertical-align: middle;
    margin-left: .15rem;
}
.flow-logo{
    vertical-align: middle;
    margin-left: 0.15rem;
    height: 0.07rem;
    width: 0.04rem;
}
.flow-text{
    vertical-align: middle;
    font-size: .16rem;
    font-family:PingFangSC-Medium;
    color:rgba(155,155,155,1);
    display: inline-block;
    margin-left: 0.1rem;
    line-height:0.22rem; 
}
.flow-text1{
    vertical-align: middle;
    font-size: .16rem;
    font-family:PingFangSC-Medium;
    color:rgba(155,155,155,1);
    display: inline-block;
    padding: 0 .03rem;
}
.flow-text:hover {
    color:rgba(73,137,182,1);
}
.flow-text1:hover {
    color:rgba(73,137,182,1);
}

.typeName {
    font-size:.24rem;
    color:rgba(73,137,182,1);
    line-height:.33rem;
    float: left;
    margin-left: 0;
}
.resultPart{
    float: right;
    width: 9.13rem;
}
.searchResult {
    margin-top: .09rem;
    width: 100%;
    overflow: hidden;
}
.course-item:hover{ 
    border: .01rem solid #4989B6;
}
.course-item {
    background:rgba(73,137,182,0.1);
    border-radius:7px;
    margin: 0 0 .51rem 0;
    height: 1.71rem;
    border-width: .01rem;
    position: relative;
    border: .01rem solid white;
}
.courseName {
    font-size:.22rem;
    font-family:PingFangSC-Regular;
    font-weight:400;
    color:rgba(0,52,89,1);
    position: absolute;
    top: .3rem;
    left: .3rem;
}
.course {
    font-size: .15rem;
    font-family:PingFangSC-Regular;
    font-weight:400;
    color:rgba(169,177,183,1);
}
.crossLine{
    background:rgba(0,52,89,1);
    opacity:0.2786;
    width: 100%;
    position: absolute;
    top: 1.15rem;
    border-top: .03rem solid rgba(232,232,232,1);
}
.courseInfo{
    text-align: left;
    bottom: .18rem;
    position: absolute;
}
.r-logo {
    display: inline-block;
    height: .13rem;
    vertical-align: middle;
    margin: 0 .12rem 0 .3rem;
}
.course {
    display: inline-block;
    font-size: .14rem;
    vertical-align: middle;
    margin-right: .16rem;
}
.line {
    background:rgba(232,232,232,1);
    opacity:0.8026000000000001;
    height: .01rem;
    margin: .2rem 0 .72rem 0;
    width: 12rem;
    display: inline-block;
}
</style>


