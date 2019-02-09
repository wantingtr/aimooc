<template>
  <div class="dialog">
      <!--外层的遮罩 点击事件用来关闭弹窗，isShow控制弹窗显示 隐藏的props-->
      <div class="dialog-cover back"  v-if="isShow" ></div>
        <!-- transition 这里可以加一些简单的动画效果 -->
        <transition name="drop">
            <!--style 通过props 控制内容的样式  -->
            <!--
            <div class="dialog-content" :style="{top:topDistance+'%',width:widNum+'%',left:leftSite+'%'}"  v-if="isShow">
            -->
            <div class="dialog-content" v-if="isShow">
                <div class="login-main">
                    <div class="input-info">
                        <div class="input-item">
                            <img src="../../static/img/login_logo_email.png" alt="" class="input-icon"> 
                            <input type="text" placeholder="请输入您的邮箱" name="id" class="input-text">
                        </div>
                        <div class="input-item">
                            <img src="../../static/img/login_logo_password.png" alt="" class="input-icon">
                            <input type="text" placeholder="请设置您的密码" name="key" class="input-text">
                        </div>
                    </div>
                    <div class="login-button">
                        <img src="../../static/img/login_button_default.png" alt="" class="button-img">
                        <div class="button-text" @click="loginClick">注册</div>
                    </div>
                    <div class="sign-up">
                        <div class="signup">已经有账户了？</div>
                        <div class="login" @click="loginClick">立即登录！</div>
                    </div>
                    <div class="others">
                        <div class="line"></div>
                        <div class="other">使用社交账号注册</div>
                        <div class="line"></div>
                    </div>
                    <div class="wechat">
                        <img src="../../static/img/login_wechat_default.png" alt="" class="wechat-icon">
                    </div>
                </div>
                <div class="close">
                    <img src="../../static/img/login_icon_cancel.png" alt="" class="close-icon" @click="closeMyself">
                </div>
            </div>
        </transition>
  </div>
</template> 


<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
    name:'signout',
    methods: {
        closeMyself() {
            this.$emit("closeMyself")
        },
        loginClick() {
            this.$router.push({path:'/login'})
        }
    },
    props: {
        isShow: {
            default: false
        }
    }
})
</script>


<style scoped>
/*最外层 设置position定位 */
  .dialog {
    position: relative;
    color: #2e2c2d;
    font-size: 16px;
  }
  /*遮罩 设置背景层，z-index值要足够大确保能覆盖，高度 宽度设置满 做到全屏遮罩*/
  .dialog-cover {
    background: rgba(0,0,0, 0.4);
    position: fixed;
    z-index: 200;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
  }
  /*内容层 z-index要比遮罩大，否则会被遮盖，*/
  .dialog-content{
    position: fixed;
    /*移动端使用felx布局
    display: flex; */
    flex-direction: column;
    justify-content: center;
    align-items: center;
    z-index: 300;
    width: 31.7%;
    top: 25%;
    right: 35.7%;
    height: 5.4rem;
 }
 .login-main{
    background-color: #ffffff;
    width: 5.5rem;
    height: 5.4rem;
    text-align: center;
    border-radius:8px;
    display: inline-block;
 }

 .login-button{
    position: absolute;
    top: 2.68rem;
 }

 .button-img{
    width: 3.9rem;
    height: .66rem;
    margin: 0 .8rem;
    display: inline;
 }
.button-text{
    color: #ffffff;
    font-size: .18rem;
    position: absolute;
    top: 0;
    line-height: .66rem;
    width: 100%;
}
.input-info{
    position: absolute;
    top: .9rem;
    width: 5.5rem;
}
input{
    border: none;
    border-bottom: 1px solid rgba(73,137,182,0.2);
    font-size: .18rem;
    outline: none;
    width: 3.66rem;
    padding-bottom: .16rem;
    padding-top: .07rem;
}
.input-icon{
    width: .3rem;
    margin-right: .24rem;
    vertical-align: bottom;
    margin-bottom: .1rem;
}
.input-item{
    height: .41rem;
    margin-bottom: .32rem;
}
.sign-up{
    font-size: .16rem;
    color:rgba(0,52,89,1);
    line-height:16px;
    top: 3.62rem;
    position: absolute;
    width: 5.5rem;
}
.signup{
    opacity: 0.5;
    display: inline-block;
    font-size: .156rem;
}
.login{
    color:rgba(73,137,182,1);
}
.others{
    bottom: .95rem;
    position: absolute;
    margin: 0 .28rem;
}
.line{
    width:1.86rem;
    height:.01rem;
    background:rgba(73,137,182,1);
    opacity:0.1968;
    display: inline-block;
    
}
.other{
    display: inline-block;
    margin: 0 .19rem;
    color: #4989B6;
    opacity: 0.5;
    line-height:20px;
    font-size: .14rem;
}
.wechat{
    width: 5.5rem;
    position: absolute;
    bottom: .33rem;
}
.wechat-icon{
    width: .42rem;
    height: .42rem;
}
.close{
    vertical-align: top;
    margin-left: .17rem;
    display: inline-block;
}
.close-icon{
    width: .36rem;
}
</style>
