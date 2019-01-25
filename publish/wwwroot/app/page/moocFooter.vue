
<template> 
    <div class = "footBack"> 
      <div class="foot-line"></div>
      <!--
        <div class = "footer-img"></div>        
        <div class="fcontainer"></div>
      -->            
        <p> 版权所有：广东职业教育信息化研究会</p>
    </div>
  </template> 

<script>
export default {
    name: 'moocFooter'
}
</script>
  

<style> 
      .footBack {
        color: #000;        
        text-align: center;    
        position: relative;    
        min-height: .44rem;
        background: #4485B5;
      }
      .foot-line{
        border-top: .01rem solid rgba(232,232,232,1);
        width: 62.5%;
        height: .1rem;
        margin: 0 auto;
      }
      .footBack .fcontainer {    
        width:100%;    
        background: #232323;
        left: 0;
        position: absolute;
        z-index: 1;
        width: 100!important;
      }
      .footBack.footer-img {
        /*background: url(../../static/img/footer01.png) no - repeat 50% ;*/
        background: rgba(73,137,182,1);
        height : 368 px;
        z-index: 2;
        position: absolute;
        width: 100%;
      }
      .footBack p {
        font-size: .15rem;
        margin-bottom: .1rem;
      }
      @keyframes heartScale {
        0% {
          transform: scale(1)
        }
        50% {
          transform: scale(0.8)
        }
        100% {
          transform: scale(1)
        }
      } 
      @media screen and (max-width: 400px) {
        .foot-line{
          width: 88%;
        }
      }

</style>