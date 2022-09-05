using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _2._8使用ReaderWriterLockSlim类
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Thread(Read) { IsBackground = true }.Start();
            new Thread(Read) { IsBackground = true }.Start();
            new Thread(Read) { IsBackground = true }.Start();

            new Thread(() => Write("线程 1"))
            {
                IsBackground = true
            }.Start();

            Thread.Sleep(TimeSpan.FromSeconds(30));

            Console.ReadKey();
        }

        private static ReaderWriterLockSlim rw = new ReaderWriterLockSlim();
        private static Dictionary<int, int> item = new Dictionary<int, int>();

        private static void Read()
        {
            Console.WriteLine("读取字典内容");
            //while (true)
            //{
                try
                {
                    //尝试进入读取模式锁定状态
                    rw.EnterReadLock();
                    foreach (var key in item.Keys)
                    {
                        Console.WriteLine("读取模式---键{0}",key);
                        Thread.Sleep(TimeSpan.FromSeconds(0.1));
                    }
                }
                catch (Exception ex) 
                {
                    throw ex;
                }
                finally
                {
                    //减少读取模式的递归计数，并在生成的计数为0（零）时退出读取模式
                    rw.ExitReadLock();
                } 
            ///}
        }
        private static void Write(string threadName)
        {
           // while (true)
            //{
                try
                {
                    int newKey = new Random().Next(250);
                    //可升级读模式，这种方式和读模式的区别在于它还有通过调用  EnterWriteLock 或 TryEnterWriteLock方法升级为写入模式
                    //因为每次只能有一个线程处于可升级模式。进入可升级模式的线程，不会影响读取模式的线程，即当一个线程进入可升级模式，
                    //任意数量线程可以同时进入读取模式，不会阻塞
                    //如果有多个线程已经在等待获取写入锁，那么运行EnterUpgradeableReadLock将会阻塞，直到那些线程超时或者退出写入锁
                    rw.EnterUpgradeableReadLock();
                    if (!item.ContainsKey(newKey))
                    {
                        try
                        {
                            //尝试进入写入模式锁定状态
                            rw.EnterWriteLock();
                            item[newKey] = 1;
                            Console.WriteLine("新键{0}添加到字典中通过{1}",newKey,threadName);
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            //减少写入模式的递归计数，并在生成的计数为0（零）时退出写入模式
                            rw.ExitWriteLock();
                        }
                    }
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    rw.ExitUpgradeableReadLock();
                }
            //}
        }
    }
}
