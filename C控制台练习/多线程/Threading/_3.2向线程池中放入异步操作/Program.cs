﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _3._2向线程池中放入异步操作
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //将方法排入队列（先进先出）   当此线程池中有线程可用时，执行此方法
            ThreadPool.QueueUserWorkItem(AsyncOperation);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            //队列（先进先出）
            ThreadPool.QueueUserWorkItem(AsyncOperation,"async state");
            Thread.Sleep(TimeSpan.FromSeconds(2));

            ThreadPool.QueueUserWorkItem(state => {
                Console.WriteLine($"操作状态:{state}");
                Console.WriteLine($"工作线程Id:{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(TimeSpan.FromSeconds(2));
            },"lambda state");

            const int x = 1;
            const int y = 2;
            const string lambdaState = "lambda state 2";
            //使用闭包机制  无需传递lambda表达式的状态参数
            ThreadPool.QueueUserWorkItem( _=>{
                Console.WriteLine($"操作状态:{x+y},{lambdaState}");
                Console.WriteLine($"工作线程Id:{Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(TimeSpan.FromSeconds(2));
            });

            Console.ReadKey();
        }
        static void AsyncOperation(object state)
        {
            Console.WriteLine($"操作状态：{state??"(null)"}");
            Console.WriteLine($"工作线程Id:{Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
    }
}
