<template>
  <div>
    <div class="content">
        <div class="flow">
            <img v-on:click="jumpHome" src="../../../static/img/home.png" class="logo">
            <div class="flow-text" v-on:click="jumpHome">
                相关课程
            </div>
            <img src="../../../static/img/next.png" class="flow-logo">
            <img src="../../../static/img/video.png" class="logo1">
            <div class="flow-text1">
                    {{info.courseName}}
            </div>
        </div>
        <div class="videoPlaying">
            <div class="introduction">
                <div class="c-title">
                    {{info.courseName}}
                </div>
                <div class="line"></div>
                <div class="fit">
                    <div class="fit-item">
                        <img src="../../../static/img/time.png" class="fit-logo">
                        <div class="fit-text">{{info.courseTime}}</div>
                    </div>
                    <div class="fit-item">
                        <img src="../../../static/img/beginner.png" class="fit-logo">
                        <div class="fit-text">{{info.courseLevel}}</div>
                    </div>
                </div>
                <div class="line"></div>
                <div class="brief">
                    {{info.courseIntro}}
                </div>
            </div>
            <div class="video-container">
                <video :src="info.courseURL" class="video" controls></video>
            </div>
        </div>
        <div class="line1"></div>
    </div>
    
    <div class="relation">
        <div class="c-title">
            相关课程
        </div>
        <div class="relativeCourse">
            <div v-for="(item, index) in list" :key = index class="course-item" v-on:click="jumpVideo(item.courseID)">
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

    </div>

  </div>
    
</template>

<script lang="ts">
import fetchVideos from '../../../api/fetchVideos'
import * as $ from 'jquery'
import Vue from 'vue'
import Component from 'vue-class-component'

export default Vue.extend({
    name: 'mainContent',
    data(){    
        //const list: string[] = [] 
       // alert('go1');   
        return{
            info: {},
            list : [],
            error: null,
            status : false
        }
    },
    created(){

        // alert('1');
        
    },
    methods: {
		// fetchVideos : function() {
		// 	this.info = "Fetching"
		// 	getVideoList
		// 		.getVideoList()
		// 		.then((data) => {
        //             this.list = data;
        //             this.info = "Done"
		// 		});
        // }
        jumpHome() {
            this.$router.push({path: "/"});
        },
        jumpVideo(id:string) {
          // alert(id);
           this.$router.push({path: '/video?courseID='+id});
           this.status = true;
        },
    },
    watch: { 
        '$route' (to, from) { 
        this.$router.go(0); 
    }},
    updated() {
    },
    mounted(){

        fetchVideos
            .getVideo(this.$route.query.courseID)
            .then((data) => {
                //this.relationList = data.relationVideoList;
                this.info = data.video;
                this.list = data.relationVideoList;
                //alert(this.info.courseTime);
            });       
    }
})
</script>

<!--
<script>
import fetchVideos from '../../../api/fetchVideos'
import $ from 'jquery'
export default {
    name: 'mainContent',
    data(){

        
       // alert('go1');
       
        
        
        return{
            info: {},
            list : [],
            error: null,
            status : false
        }
    },
    created(){

        // alert('1');
        
    },
    methods: {
		// fetchVideos : function() {
		// 	this.info = "Fetching"
		// 	getVideoList
		// 		.getVideoList()
		// 		.then((data) => {
        //             this.list = data;
        //             this.info = "Done"
		// 		});
        // }
        jumpHome() {
            this.$router.push({path: "/"});
        },
        jumpVideo(id) {
          // alert(id);
           this.$router.push({path: '/video?courseID='+id});
           status = true;
        },
    },
    watch: { 
    '$route' (to, from) { 
     this.$router.go(0); 
    }},
    updated() {
    },
    mounted(){
			fetchVideos
				.getVideo(this.$route.query.courseID)
				.then((data) => {
                    //this.relationList = data.relationVideoList;
                    this.info = data.video;
                    this.list = data.relationVideoList;
                    //alert(this.info.courseTime);
				});       
    }
}
</script>
-->

<style scoped>

.relation {
    width: 62.5%;
    margin: 0 auto;
    overflow: hidden;
}
.c-title {
    font-size: .24rem;
    font-family:PingFangSC-Regular;
    font-weight:400;
    color:rgba(73,137,182,1);
    margin-top: .32rem;
}
.relativeCourse {
    float: right;
    width: 9.13rem;
    margin-top: .09rem;
}
.course-item {
    background:rgba(73,137,182,0.1);
    border-radius:7px;
    margin: 0 0 .51rem 0;
    height: 1.71rem;
    position: relative;
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



.content{
    width: 62.5%;
    margin: 0 auto;
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
.introduction{
    float: left;
    text-align: left;
    vertical-align: middle;
}
.videoPlaying{
    font-size: 0;
    overflow: hidden;
}
.video-container{
    float: right;
}
.video{
    width: 7.57rem;
    height: 4.36rem;
    border-radius: .15rem;
}
.c-title{
    font-size: .24rem;
    font-family:PingFangSC-Regular;
    font-weight:400;
    color:rgba(73,137,182,1);
}
.fit-text{
    font-size: .14rem;
    font-family:PingFangSC-Regular;
    font-weight:400;
    color:rgba(155,155,155,1);
    line-height: .20rem;
}
.brief{
    font-size: .16rem;
    width:3.68rem;
    font-family:PingFangSC-Regular;
    font-weight:400;
    color:rgba(74,74,74,1);
    margin-top: .23rem;
    line-height: .22rem;
}
.line{
    width: 3.5rem;
    opacity:0.8;
    height: .01rem;
    margin: .25rem 0 0 ;
    border-top: .01rem solid rgba(232,232,232,1);
}
.line1{
    width: 100%;
    opacity:0.8;
    border-top: .01rem solid rgba(232,232,232,1);
    margin-top: 1.03rem;
}
.fit-item{
    text-align: left;
    margin-top: .25rem;
}
.fit-text{
    display: inline-block;
    vertical-align: middle;
    margin-left: .12rem;
}
.fit-logo{
    height: .18rem;
    width: .18rem;
    display: inline-block;
    vertical-align: middle;
}
.next{
    position: relative;
    font-size: 0;
    float: right;
    margin-top: .47rem;
}
.next-text:hover {
    color:rgba(73,137,182,1);
}
.next-text{
    font-size: .14rem;
    font-family:PingFangSC-Regular;
    font-weight:400;
    color:rgba(155,155,155,1);
    display: inline-block;
    vertical-align: middle;
}
.next-logo{
    vertical-align: middle;
    display: inline-block;
    margin-left: .11rem;
}
@media screen and (max-width: 400px) {
    .content{
        width: 88%;
    }
    .flow {
        margin: .18rem 0 .26rem 0;
        float: none;
    }
    .video-container{
        float: none;
    }
    .fit-item{
        margin: .21rem .26rem .21rem 0;
        display: inline-block;
    }
    .logo {
        height: .1rem;
        width: .1rem;
        padding: 0;
    }
    .logo1 {
        height: .1rem;
        width: .1rem;
        padding: 0;     
        margin-left: .1rem;  
    }
    .fit-text {
        font-size: .1rem;
        margin-left: .08rem;
    }
    .fit-logo {
        height: .13rem;
        width: .13rem;
        display: inline-block;
    }
    .flow-logo{
        margin-left: 0.1rem;
        height: 0.05rem;
        width: 0.03rem;
    }
    .flow-text {
        display: none;
        font-size: .1rem;
        margin: .1rem;
    }
    .flow-text1 {
        font-size: .1rem;
        margin-left: .1rem;
    }
    .c-title {
        font-size: .16rem;
        margin-bottom: .14rem;
        line-height: .22rem;
    }
    .brief {
        font-size: .12rem;
        line-height: .17rem;
        margin-top: .18rem;
        width: 3.31rem;
    }
    .line{
        margin: 0
    }
    .video{
        width: 3.31rem;
        height: 1.93rem;
        border-radius: .05rem;
        margin: .3rem 0 .26rem 0;
    }
    .next{
        margin: 0;
        float: none;
    }
    .next-logo{
        position: absolute;
        vertical-align: top;
        height: .11rem;
        margin-top: .02rem;
        right: 0;
    }
    .next-text{
        width: 92%;
        font-size: .12rem;
        line-height: .17rem;
    }
    .line1{
        margin-top: .22rem;
    }
    
    .relation {
        padding: 0 auto;
        width: 88%;
    }
    .c-title {
        font-size: .16rem;
        margin: .2rem 0 .3rem 0;
    }
    .relativeCourse {
        width: 100%;
        border-radius: .04rem;
    }
    .course-item {
        height: 1rem;
        margin-bottom: .18rem;
    }
    .courseName {
        font-size: .12rem;
    }
    .crossLine {
        top: .66rem;
        border-top: .01rem solid rgba(232,232,232,1);
    }
    .course {
        font-size: .1rem;
    }
    .courseInfo{
        position: absolute;
        top: .77rem;
    }
    .r-logo {
        height: .13rem;
    }
}
</style>

