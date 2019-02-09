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
                <!-- 用户登录页面-->
                <div class="login-main" v-show="signout == false && !signoutPage && !wechat">
                    <div class="input-info">
                        <div class="input-item">
                            <img src="../../static/img/login_logo_username.png" alt="" class="input-icon">
                            <input type="text" placeholder="邮箱" name="id" class="input-text">
                        </div>
                        <div class="input-item">
                            <img src="../../static/img/login_logo_password.png" alt="" class="input-icon">
                            <input type="password" placeholder="密码" name="key" class="input-text">
                        </div>
                    </div>
                    <div class="login-button">
                        <img src="../../static/img/login_button_default.png" alt="" class="button-img">
                        <div class="button-text" @click="userLogin">登录</div>
                    </div>
                    <div class="sign-up">
                        <div class="signup">没有账户？</div>
                        <div class="signout" @click="signoutClick">注册</div>
                    </div>
                    <div class="others">
                        <div class="line"></div>
                        <div class="other">其他登录方式</div>
                        <div class="line"></div>
                    </div>
                    <div class="wechat">
                        <img src="../../static/img/login_wechat_default.png" alt="" class="wechat-icon" @click="jumpWechat">
                    </div>
                </div>

                <!-- 用户注册页面-->
                <div class="login-main" v-show="signout == false && signoutPage && !wechat">
                    <div class="input-info">
                        <div class="input-item">
                            <img src="../../static/img/login_logo_email.png" alt="" class="input-icon">
                             <input type="text" placeholder="请输入您的邮箱" name="id" class="input-text">
                        </div>
                        <div class="input-item">
                            <img src="../../static/img/login_logo_password.png" alt="" class="input-icon">
                            <input type="password" placeholder="请设置您的密码" name="key" class="input-text">
                        </div>
                    </div>
                    <div class="login-button">
                        <div class="button-text" @click="userSignout">注册</div>
                    </div>
                    <div class="sign-up">
                        <div class="signup">已经有账户了？</div>
                        <div class="signout" @click="signoutClick">立即登录！</div>
                    </div>
                    <div class="others">
                        <div class="line" style="width: 1.7rem"></div>
                        <div class="other">使用社交账号注册</div>
                        <div class="line" style="width: 1.7rem"></div>
                    </div>
                    <div class="wechat">
                        <img src="../../static/img/login_wechat_default.png" alt="" class="wechat-icon" @click="jumpWechat">
                    </div>
                </div>
                
                <!--微信登录页面-->
                <div class="login-main" v-show="wechat">
                    <p class="wechatTitle">微信二维码登录</p>
                    <div class="wechatLine"></div>
                    <!--
                        <img src="../../static/img/wechat_img_qrcode.png" alt="" class="QRcode"> 
                    -->
                    <img src="../../static/img/wechat_img_qrcode.png" alt="" class="QRcode" @click="userWechatLogin">
                    <div v-show="!wechatTrue">
                        <p class="wechat-text">请使用微信扫描二维码登录<br>“广东职业教育人工智能MOOC平台”</p>
                        <div class="wechatBottom">
                            <p class="wechat-change" @click="wechatJumpLogin">密码登录</p>
                            <div class="wechatLine1"></div>
                            <p class="wechat-change" @click="wechatJumpSignout">注册新账号</p>
                        </div>
                    </div>

                    <!--微信扫描成功-->
                    <div v-show="wechatTrue" class="wechatTrueBackground">
                        <img src="../../static/img/signin_success_big.png" alt="" class="wechatTrueIcon">
                        <div style="display: inline-block;vertical-align: top;display: inline-block; margin-top: .22rem;"> 
                            <p class="wechatTrueText">扫描成功</p>
                            <p class="wechatTrueText1">请在微信中点击确认即可登录</p>
                        </div>
                    </div> 
                </div>
                <!--用户注册成功页面-->


                <div class="login-main" v-show="signout">
                    <img src="../../static/img/signin_success_big.png" alt="" class="hasSignoutIcon">
                    <p class="hasSignoutText">注册成功</p>
                    <div class="jumpLogin">
                        <p style="padding: .2rem 0;" @click="jumpLogin">去登录</p>
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
    name:'login',
    data():{login,signoutPage,signout,wechat,wechatTrue: any} {
        return {
            signoutPage: false, //登录页面与注册页面的切换
            signout: false, //用户成功注册
            login : false, //用户成功登录
            wechat: false, //微信登录界面
            wechatTrue: false, //微信扫描成功
        }
    },
    methods: {
        closeMyself() {
            this.$emit("closeMyself")
        },
        wechatJumpLogin() {
            this.wechat = false
            this.signoutPage = false
        },
        wechatJumpSignout() {
            this.wechat = false
            this.signoutPage = true
        },
        signoutClick() {
            this.signoutPage = !this.signoutPage
            //登录页面与注册页面的切换
        },
        userSignout() {
            //用户成功注册，页面跳转
            this.signout = true
        },
        jumpLogin() {
            this.signout = false//跳转到登录页面
            this.signoutPage = false
        },
        jumpWechat() {
            this.wechat = true//跳转到微信登录页面
        },
        userWechatLogin() {
            this.wechatTrue = true //用户微信扫描成功，成功登录/注册
        },
        userLogin() {
            //用户成功登录
            this.$emit("closeMyself") //关闭弹窗
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
    width: 32%;
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
 .hasSignoutIcon{
     width: 1rem;
     margin: 1.34rem 0 .41rem 0;
 }
.hasSignoutText{
    font-size: .22rem;
    color: #3D4855;
    margin-bottom: .89rem;
}
.jumpLogin{
    background: #4989B6;
    border-radius: .6rem;
    color:#ffffff;
    width: 3.9rem;
    height: .66rem;
    font-size: .2rem;
    margin: 0 auto;
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
    cursor: pointer;
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
.signout{
    color:rgba(73,137,182,1);
    display: inline-block;
    font-size: .156rem;
    cursor: pointer;
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
    cursor: pointer;
}
.close{
    vertical-align: top;
    margin-left: .11rem;
    display: inline-block;
}
.close-icon{
    width: .36rem;
}
.wechatBottom {
    position: absolute;
    left: 1.96rem;
    bottom: .44rem;
}
.wechat-text{
    font-size: .156rem;
    color: #9B9B9B;
    letter-spacing: 0;
    text-align: center;
    line-height: 16px;
    position: absolute;
    bottom: 1.21rem;
    left: 1.48rem;
}
.wechatTitle{
    font-size: .18rem;
    color: #4989B6;
    text-align: left;
    position: absolute;
    top: .48rem;
    left: .55rem;
}
.wechatLine{
    opacity: 0.2;
    top: 1.01rem;
    height: .01rem;
    background: #4989B6;
    left: .55rem;
    position: absolute;
    width: 4.4rem;
}
.QRcode{
    position: absolute;
    width: 2.2rem;
    left: 1.65rem;
    top: 1.41rem;
}
.wechat-change{
    display: inline-block;
    opacity: 0.5;
    font-size: .156rem;
    color: #003459;
    line-height: 16px;
    cursor: pointer;
}
.wechatLine1{
    height: .16rem;
    width: .01rem;
    display: inline-block;
    opacity: 0.5;
    margin: 0 .16rem;
    background: #003459;
}
.wechatTrueBackground{
    background: #efefef63;
    border-radius: .44rem;
    width: 3.46rem;
    height: .88rem;
    position: absolute;
    bottom: .51rem;
    left: 1.02rem;
}
.wechatTrueIcon{
    width: .5rem;
    display: inline-block;
    margin: .19rem .2rem .19rem 0;
}
.wechatTrueText,.wechatTrueText1 {
    font-size: .156rem;
    color: #4A4A4A;
    text-align: left;
}
.wechatTrueText1{
    font-size: .14rem;
}
</style>
