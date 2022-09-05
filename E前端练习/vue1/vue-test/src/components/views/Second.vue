<template>
    <div id="apptemp">
        <p>{{total}}</p>
        <button-counter v-on:increment="incrementTotal"></button-counter>
        <button-counter v-on:increment="incrementTotal"></button-counter>
        <br><br>
        <button-counter2></button-counter2>
        <button-counter2></button-counter2>
        <button-counter2></button-counter2>
        <br><br>
        <runoob-input v-model="num"></runoob-input>
        <p>输入的数字为:{{num}}</p>
        <br><br>
        <base-checkbox v-model="lovingVue"></base-checkbox>
        <div v-show="lovingVue">
          如果选择框打钩我就会显示
        </div>
        <br><br>
        <!-- <p>页面载入时，input元素自动获取焦点：</p>
        <input v-focus> -->
        <p>页面载入时，input元素自动获取焦点：</p>
        <input v-focus>
        <br><br>
        <div v-runoob="{color:'green',text:'菜鸟教程！'}"></div>
        <div>
          {{information}}
        </div>
        <br><br>
        <div>
          <button v-on:click="show=!show">点我</button>
          <transition name="fade">
            <p v-show="show" v-bind:style="styleobj">动画实例</p>
          </transition>
        </div>
    </div>

</template>

<script>
import Vue from 'vue'
Vue.directive('runoob', function (el, binding) {
  el.innerHTML = binding.value.text
  el.style.backgroundColor = binding.value.color
})
Vue.directive('focus', {
  inserted: function (el) {
    el.focus()
  }
})
Vue.component('base-checkbox', {
  model: {
    prop: 'checked',
    event: 'change'
  },
  Props: {
    checked: Boolean
  },
  template: `
    <input
    type="checkbox"
    v-bind:checked="checked"
    v-on:change="$emit('change', $event.target.checked)"
    >
  `
})
Vue.component('runoob-input', {
  template: `
  <p>
  <input
  ref="input"
  :value="value"
  @input="$emit('input',$event.target.value)"
  >
  </p>`,
  Props: ['value']
})
var buttonCounter2Data = {count: 0}
Vue.component('button-counter2', {
  template: '<button v-on:click="count++">点击了{{count}}次</button>',
  data: function () {
    return buttonCounter2Data
  }
})
Vue.component('button-counter', {
  template: '<button v-on:click="incrementHandler">{{counter}}</button>',
  data: function () {
    return {
      counter: 0
    }
  },
  methods: {
    incrementHandler: function () {
      this.counter += 1
      this.$emit('increment')
    }
  }
})
export default {
  name: 'Second',
  data () {
    return {
      total: 0,
      num: 100,
      lovingVue: true,
      information: '北极光之夜。',
      show: true,
      styleobj: {
        fontSize: '30px',
        color: 'red'
      }
    }
  },
  methods: {
    incrementTotal: function () {
      this.total += 1
    }
  },
  directives: {
    focus: {
      inserted: function (el) {
        el.focus()
      }
    }
  }
}
</script>
