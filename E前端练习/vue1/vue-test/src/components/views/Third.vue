<template>
<div id = "databinding">
<button v-on:click = "show = !show">点我</button>
<transition name = "fade">
    <p v-show = "show" v-bind:style = "styleobj">动画实例</p>
</transition>
<br><br>
<transition name="slide-fade">
    <p v-if="show">菜鸟教程</p>
</transition>
<br><br>
<transition name="bounce">
    <p v-if="show">菜鸟教程 -- 学的不仅是技术，更是梦想！！！</p>
</transition>
<br><br>
<transition
  v-on:before-enter="beforeEnter"
  v-on:enter="enter"
  v-on:after-enter="afterEnter"
  v-on:enter-cancelled="enterCancelled"
  v-on:before-leave="beforeLeave"
  v-on:leave="leave"
  v-on:after-leave="afterLeave"
  v-on:leave-cancelled="leaveCancelled"
>
  <!-- ... -->
</transition>
<br><br>
<!-- <div>
  <ol>
    <li v-for="todo in todos">
      {{todo.text}}
    </li>
  </ol>
</div> -->

</div>
</template>

<script type = "text/javascript">
export default {
  name: 'Third',
  data () {
    return {
      show: true,
      styleobj: {
        fontSize: '30px',
        color: 'red',
        todos: [
          {text: '123'},
          {text: '456'},
          {text: '789'}
        ]
      }
    }
  },
  methods: {
    // --------
  // 进入中
  // --------

    beforeEnter: function (el) {
    // ...
    },
    // 此回调函数是可选项的设置
    // 与 CSS 结合时使用
    enter: function (el, done) {
    // ...
      done()
    },
    afterEnter: function (el) {
    // ...
    },
    enterCancelled: function (el) {
    // ...
    },

    // --------
    // 离开时
    // --------

    beforeLeave: function (el) {
    // ...
    },
    // 此回调函数是可选项的设置
    // 与 CSS 结合时使用
    leave: function (el, done) {
    // ...
      done()
    },
    afterLeave: function (el) {
    // ...
    },
    // leaveCancelled 只用于 v-show 中
    leaveCancelled: function (el) {
    // ...
    }
  }
}
</script>

<style>
/* 可以设置不同的进入和离开动画 */
/* 设置持续时间和动画函数 */
.fade-enter-active, .fade-leave-active {
    transition: opacity 2s
}
.fade-enter, .fade-leave-to /* .fade-leave-active, 2.1.8 版本以下 */ {
    opacity: 0
}
/* 可以设置不同的进入和离开动画 */
/* 设置持续时间和动画函数 */
.slide-fade-enter-active {
  transition: all .3s ease;
}
.slide-fade-leave-active {
  transition: all .8s cubic-bezier(1.0, 0.5, 0.8, 1.0);
}
.slide-fade-enter, .slide-fade-leave-to
/* .slide-fade-leave-active 用于 2.1.8 以下版本 */ {
  transform: translateX(10px);
  opacity: 0;
}
.bounce-enter-active {
  animation: bounce-in .5s;
}
.bounce-leave-active {
  animation: bounce-in .5s reverse;
}
@keyframes bounce-in {
  0% {
    transform: scale(0);
  }
  50% {
    transform: scale(1.5);
  }
  100% {
    transform: scale(1);
  }
}
</style>
