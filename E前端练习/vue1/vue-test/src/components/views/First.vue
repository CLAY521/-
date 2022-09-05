<template>
    <div class="first-app">
        {{ msg }}
        <h1>{{site}}</h1>
        <h1>{{url}}</h1>
        <h1>{{details()}}</h1>
        <label for="r1">修改颜色</label><input type="checkbox" v-model="use" id="r1">
        <br><br>
        <div v-bind:class="{'class1':use}">
          v-bind:class指令
        </div>
        <p v-if="seen">(v-if)你现在能看到我了</p>
        <p v-else>(否则就显示这个)</p>
        <p v-show="seens">(v-show)你现在能看到我了</p>
        <pre><a v-bind:href="burl">菜鸟教程</a></pre>
        <input v-model="message"/>
        <button v-on:click="reverseMessage">反转字符串</button>
        未转换:{{message}}
        过滤器：{{message|capitalize}}
        <!-- <div id="app1">
          <ol>
            <li v-for="site in sites">
              {{ site.name }}
            </li>
          </ol>
        </div> -->
        <div>
          原始字符串：{{message}}
          计算后反转的字符串：{{reversedMessage}}
          读取（设置读写属性后的数据）：{{siteWrite}}
        </div>
        <div>
          <p style="font-size:25px;">计数器:{{counter}}</p>
          <button @click="SumCount()" style="font-size: ;:25px">点我</button>
          <div v-bind:class="{'active':isActive,'text-danger':isActive}"></div>
          <br><br>
          <div v-bind:class="[activeClass,errorClass]"></div>
          <br><br>
          <div v-bind:style="{ color: activeColor, fontSize: fontSize + 'px' }">(未加粗)菜鸟教程</div>
          <div v-bind:style="[baseStyles,overridingStyles]">(加粗)菜鸟教程</div>
          <br><br>
          <div id="app">
            <button v-on:click="counters+=1">增加1</button>
            <p>这个按钮被点击了{{counters}}次。</p>
          </div>
          <button v-on:click="greet">Greet</button>
          <button v-on:click="canshu('aaa')">传参</button>
          <button v-on:click.left="lefts()">左击事件</button>
          <button v-on:click.right="rights()">右击事件</button>
          <button v-on:click.middle="middles()">中间滚轮事件</button>
          <input v-model="message">
          <input v-model="msg">
          <br><br>
          <span>双向绑定  mvvm--</span>
          <input type="radio" id="runoob" value="Runoob" v-model="picked">
          <labe for="runoob">Runoob</labe>
          <input type="radio" id="google" value="Google" v-model="picked">
          <label for="google">Google</label>
          <span>选中的值为:{{picked}}</span>
          <br><br>
          <p>单个复选框</p>
          <input type="checkbox" id="checkbox" v-model="checked">
          <label for="checkbox">{{checked}}</label>
          <p>多个复选框</p>
          <input type="checkbox" id="runoob" value="Runoob" v-model="checkedNames">
          <label for="runoob">Runoob</label>
          <input type="checkbox" id="google" value="google" v-model="checkedNames">
          <label for="google">Google</label>
          <input type="checkbox" id="taobao" value="taobao" v-model="checkedNames">
          <label for="taobao">Taobao</label>
          <span>选择的值为:{{checkedNames}}</span>
          <br><br>
          <select v-model="selected" name="fruit">
            <option val="">选择一个网站</option>
            <option value="www.runoob.com">Runoob</option>
            <option value="www.google.com">Google</option>
          </select>
          <div id="output">
            选择的网站是:{{selected}}
          </div>
          <runoob></runoob>
          <runoob1></runoob1>
          <child message="hello"></child>
          <child v-bind:message="parentMsg"></child>
          <input v-model="parentMsg">
          <br><br>
          <p>{{total}}</p>
          <button-counter v-on:increment="incrementTotal"></button-counter>
          <button-counter v-on:increment="incrementTotal"></button-counter>
        </div>
    </div>
</template>

<script>
import Vue from 'vue'

Vue.component('button-counter', {
  template: '<button v-on:click="incrementHandler">{{counter2}}</button>'
})
Vue.component('runoob', {
  template: '<h1>自定义组件!</h1>'
})
var Child = {
  template: '<h1>局部组件</h1>'
}
Vue.component('child', {
  props: ['message'],
  template: '<h1 style="color:red">{{message}}</h1>'
})
// Vue.component('tao-item', {
//   props: ['todo'],
//   template: '<li>{{todo.text}}}</li>'
// })
export default {
  name: 'First',
  components: {
    'runoob1': Child
  },
  data () {
    return {
      total: 0,
      counter2: 0,
      // sites: [
      //   {text: 'Runoob'},
      //   {text: 'Google'},
      //   {text: 'Taobao'}
      // ],
      parentMsg: '父组件内容',
      selected: '',
      checked: false,
      checkedNames: [],
      picked: 'Runoob',
      counters: 0,
      activeColor: 'green',
      fontSize: 30,
      baseStyles: {
        color: 'green',
        fontSize: '30px'
      },
      overridingStyles: {
        'font-weight': 'bold'
      },
      isActive: true,
      activeClass: 'active',
      errorClass: 'text-danger',
      counter: 1,
      message: 'runoob.com',
      burl: 'www.runoob.com',
      seens: true,
      seen: true,
      msg: 'Welcome to FirstApp',
      site: '菜鸟教程',
      url: 'www.runoob.com',
      alexa: '10000',
      use: false
    }
  },
  methods: {
    incrementTotal: function () {
      this.total += 1
    },
    incrementHandler: function () {
      this.counter2 += 1
      this.$emit('increment')
    },
    lefts: function () { alert('左') },
    righst: function () { alert('右') },
    middles: function () { alert('滚轮') },
    greet: function (event) {
      alert('Hello' + this.site + '!')
      if (event) {
        alert(event.target.tagName)
      }
    },
    canshu: function (message) {
      alert('参数是:' + message.toString())
    },
    details: function () {
      return this.site + '学的不仅是技术，更是梦想！'
    },
    reverseMessage: function () {
      this.message = this.message.split('').reverse().join('')
    },
    SumCount: function () {
      this.isActive = !this.isActive
      var before = this.counter
      this.counter++
      alert('前' + before + '后' + this.counter)
    }
  },
  filters: {
    capitalize: function (value) {
      if (!value) return ''
      value = value.toString()
      return value.charAt(0).toUpperCase() + value.slice(1)
    }
  },
  computed: {
    reversedMessage: function () {
      return this.message.split('').reverse().join('')
    },
    siteWrite: {
      get: function () {
        return this.site + ' ' + this.url
      },
      set: function (newValue) {
        var names = newValue.split(' ')
        this.site = names[0]
        this.url = names[names.length - 1]
      }
    }
  }
}
</script>

<style>
.class1{
  background:#444;
  color:#eee;
}
.active{
  width: 100px;
  height: 100px;
  background: green;
}
.text-danger{
  background: red;
}
</style>
