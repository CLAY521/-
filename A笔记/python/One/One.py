#from pickle import TRUE


#classmates = ["rere","ew","wq"]  # list一个集合
#print(len(classmates))  # list的长度

#classmates.append("Admin")  #在末尾追加
#print(classmates)

#classmates.insert(0,"first") # 在下标为0的位置追加
#print(classmates)

#classmates.pop()  # 删除list末尾的方法
#print(classmates)

#classmates.pop(1); # 删除下标为1的元素
#print(classmates)

#classmates[1] = 'Sarah'  # 替换list里面的元素
#print(classmates)

#L = ["Apple",123,TRUE]  # list中可以是数据类型不一样的数据

#s = ['python','java',['asp','php'],'scheme']
#len(s)
#print(s)  

#元组  tuple
#L = [
#    ['Apple', 'Google', 'Microsoft'],
#    ['Java', 'Python', 'Ruby', 'PHP'],
#    ['Adam', 'Bart', 'Lisa']
#]
# 打印Apple:
#print(L[0][0])
# 打印Python:
#print(L[1][1])
# 打印Lisa:
#print(L[2][2])

#list(集合) 和 tuple(元组)的区别
  #前者可以进行操作   后者不可以  只能读取  不能追加，删除和赋值

#条件判断
#age = 20
#if age >= 6:
#    print('teenager')
#elif age >= 18:
#    print('adult')
#else:
#    print('kid')

#循环
#sun = 0

#for x in range(101):
#    sun = sun+x
#print(sun)

#sums = 0
#n=99
#while n > 0:
#    if n==95:
#        continue
#    if n==39:
#        break
#    sums = sums+n
#    n = n-2
#print(sums)

# dic字典和set集合（无序和无重复元素的集合）
#d = {'Michael':95,'Bob':75,'Tracy':85}
#print(d['Tracy'])
#print('Tracy' in d) #查找当前key是否存在
## 查找当前key是否存在  如果不存在返回 none  或者  自己指定的值   如果存在返回value
#print(d.get('12213'))
#print(d.get('12213'))
#print(d.get('Tracy'))
#删除key
#d.pop('Bob')

#set
#s = set([1,2,3,3,3,3,3,3,3])  #重复的元素在set中自动过滤
#s2 = set([7,8,9,1])
#s.add(4)                  #在末尾追加元素
#s.add(5)

#s.remove(4)  #删除指定的元素
#print(s)

#result = s&s2     #交集
#print(result)

#result2 = s | s2  #并集
#print(result2)

#a = 'abc'
#a.replace('a','A')
#print(a.replace('a','A'))

#e = {(1,2,3):95,'Bob':75,'Tracy':85}
#print(e[(1,2,3)])       #证明  只要是不变对象就可以作为key(tuple元组是不变对象)

#函数
#print('你好')

#print(abs(-100))

#help(abs)

#n1 = 255
#n2 = 1000
#print(hex(n2))

#定义函数
#def my_abs(x):
#    if x>=0:
#        return x
#    else:
#        return -x
#print(my_abs(-100))


def fact_iter(num,product):
    if num==1:
        return product
    return fact_iter(num-1,num*product)

def fact_add(num,product):
    if num==1:
        return product
    return fact_add(num-1,num+product)

print(fact_iter(5,1))  #阶乘

print(fact_add(5,1))   #阶和

