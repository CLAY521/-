using ServiceStack.Redis;
using ServiceStack.Redis.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace redis
{
    public class Program
    {
        public static RedisClient client = new ServiceStack.Redis.RedisClient("127.0.0.1", 6379);
        static void Main(string[] args)
        {
            Console.ReadKey();
        }

        #region Cache类   .Net下的缓存
        public static void Caches()
        {
            Person p = new Person();
            p.Id = 1;p.Name = "诸葛亮";

            Cache cache = HttpRuntime.Cache;
            cache.Insert("AA",p);
            cache.Insert("BB","字符串");

            Console.WriteLine("输出bb的值：" + cache.Get("BB").ToString());
            Person p2 = cache["AA"] as Person;
            Console.WriteLine("输出人对象的值：" + p2.Id+":"+p2.Name);
            Console.WriteLine("输出缓存的字节数：" + cache.EffectivePrivateBytesLimit);       
            Console.WriteLine("缓存中移除项之前应用程序可使用的物理内存百分比：" + cache.EffectivePercentagePhysicalMemoryLimit);

            Console.WriteLine("缓存中数据的数量：" + cache.Count);
            Console.WriteLine("bb的值：" + cache["BB"]);

            cache.Remove("BB");
            Console.WriteLine("移除bb之后  输出bb不报错：" + cache["BB"]);

            foreach (var obj in cache)
            {
                Console.WriteLine("输出缓存的子项："+obj);
            }
        }

        public static void _Default()
        {
            Cache cache = HttpRuntime.Cache;
            cache.Insert("CC","依赖项测试",new CacheDependency(@"E:\123.txt"));
            Console.WriteLine(cache["CC"]);
        }

        public static void ExpirationTime()
        {
            Cache cache = HttpRuntime.Cache;
            cache.Insert("DD", "绝对过期测试", null, DateTime.Now.AddSeconds(5),System.Web.Caching.Cache.NoSlidingExpiration);
        }
        public static void SlideExpirationTime()
        {
            Cache cache = HttpRuntime.Cache;
            cache.Insert("DD", "滑动过期测试", null, System.Web.Caching.Cache.NoAbsoluteExpiration,TimeSpan.FromSeconds(10));
        }
        public static void Priority()
        {
            Cache cache = HttpRuntime.Cache;
            cache.Add("MyData","缓存重要级别",null,Cache.NoAbsoluteExpiration,TimeSpan.FromSeconds(30),CacheItemPriority.High,null);
        }

        #region 当缓存被移除时   通知程序
        //Add方法  设置过期时间    
        //Insert方法  永不过期
        public static void AddCaches()
        {
            Cache cache = HttpRuntime.Cache;
            cache.Add("MyData","缓冲移除通知",null,DateTime.Now.AddSeconds(10),Cache.NoSlidingExpiration,CacheItemPriority.Low, Show);
            cache.Remove("MyData");
        }
        public static void Show(string key, object value, CacheItemRemovedReason reason)
        {
            Cache cache = HttpRuntime.Cache;
            cache.Insert("MyData","缓存清空啦！缓存清空啦！");
            Console.WriteLine(cache["MyData"]);
        }
        #endregion

        //........还有很多

        #endregion
        //事务
        public static void TransactionsRedis()
        {
            using (IRedisClient c = client)
            {
                c.Add("key",1);
                using (IRedisTransaction trt = c.CreateTransaction())
                {
                    trt.QueueCommand(a=>a.Set("key",20));
                    trt.QueueCommand(a=>a.Increment("key",1));
                    trt.Commit();
                }
                Console.WriteLine(c.Get<string>("key"));
            }
        }
        public static void ClockRedis()
        {
            using (IRedisClient c = client)
            {
                c.Add("mykey",1);
                using (c.AcquireLock("testLock"))
                {
                    Console.WriteLine("申请并发锁");
                    var counter = c.Get<int>("mykey");
                    Thread.Sleep(100);
                    c.Set("mykey",counter+1);
                    Console.WriteLine(c.Get<int>("mykey"));
                }
            }
        }
        //把缓存当集合用
        public static void IEntityStores()
        {
            Person p1 = new Person() { Id = 1, Name = "刘备" };
            Person p2 = new Person() { Id = 2, Name = "关羽" };
            Person p3 = new Person() { Id = 3, Name = "张飞" };
            Person p4 = new Person() { Id = 4, Name = "曹操" };
            Person p5 = new Person() { Id = 5, Name = "典韦" };
            Person p6 = new Person() { Id = 6, Name = "郭嘉" };
            List<Person> ListPerson = new List<Person>() { p2, p3, p4, p5, p6 };
            using (IRedisClient RClient = client)
            {
                IRedisTypedClient<Person> IRPerson = RClient.As<Person>();
                IRPerson.DeleteAll();   //全部删除
                //添加
                IRPerson.Store(p1);
                //添加多条数据
                IRPerson.StoreAll(ListPerson);
                //查询
                Console.WriteLine(IRPerson.GetAll().Where(a=>a.Id==1).First().Name);
                Console.WriteLine(IRPerson.GetAll().First(a=>a.Id==2).Name);
                //删除
                IRPerson.Delete(p1);
            }
        }
        public static void Transactions()//事务  在原有的基础上加1
        {
            client.Add("key",1);
            using (IRedisTransaction IRT = client.CreateTransaction())
            {
                IRT.QueueCommand(r => r.Set("key", 20));
                IRT.QueueCommand(r=>r.Increment("key",1));
                IRT.Commit();//提交事务
            }
            Console.WriteLine(client.Get<string>("key"));
        }
        public static void Clock()
        {
            client.Add("mykey",1);
            //支持IRedisTypedClient 和 IRedisClient
            //using (client.AcquireLock("testlock"))
            //{
                Console.WriteLine("申请并发锁");
                var counter = client.Get<string>("mykey");
                Thread.Sleep(100);
                client.Set("mykey",counter+1);
                Console.WriteLine(client.Get<string>("mykey"));
            //}
        }    //锁
        public static void StringRedis(string key,string value)//字符串
        {
            RedisClient c = new RedisClient("127.0.0.1", 6379);
            //存储
            c.Set<string>(key,value);
            //client.Set<string>("pwd","123456");
            ////读取
            //Console.WriteLine(client.Get<string>("name"));
            //Console.WriteLine(client.Get<string>("pwd"));
        }
        public static string GetStringRedis(string key)//字符串
        {
            RedisClient c = new RedisClient("127.0.0.1", 6379);
            //存储
            var result = c.Get<string>(key);
            return result;
            //client.Set<string>("pwd","123456");
            ////读取
            //Console.WriteLine(client.Get<string>("name"));
            //Console.WriteLine(client.Get<string>("pwd"));
        }
        //删除key
        public static void DeleteStringRedis(string key)//字符串
        {
            string[] keys = key.Split(',');
            using (RedisClient c = new RedisClient("127.0.0.1", 6379))
            {
                c.RemoveAll(keys);
            }  
        }
        public static void HashRedis()//哈希
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("1","2"); dic.Add("2","3"); dic.Add("3","4");
            client.SetRangeInHash("hash",dic);
            Dictionary<string, string> dics = client.GetAllEntriesFromHash("hash");
            foreach (var item in dics)
            {
                Console.WriteLine("hash的key为:{0},值为:{1}",item.Key,item.Value);
            }
        }
        public static void ListRedis()//列表
        {
            #region List队列操作
            client.EnqueueItemOnList("QueueList", "打印任务1"); //入队
            client.EnqueueItemOnList("QueueList", "打印任务2");
            client.EnqueueItemOnList("QueueList", "打印任务3");
            client.EnqueueItemOnList("QueueList", "打印任务4");
            long q = client.GetListCount("QueueList");
            Console.WriteLine("打印任务按照顺序打印开始");
            for (int i = 0; i < q; i++)
            {
                Console.WriteLine("QueueList出队值：{0}", client.DequeueItemFromList("QueueList"));
            }
            Console.WriteLine("打印任务按照顺序打印完成");
            #endregion
            #region 栈操作
            client.PushItemToList("StackList", "入栈操作1"); //入栈
            client.PushItemToList("StackList", "入栈操作2");
            client.PushItemToList("StackList", "入栈操作3");
            client.PushItemToList("StackList", "入栈操作4");
            Console.WriteLine("开始出栈");
            long p = client.GetListCount("StackList");
            for (int i = 0; i < p; i++)
            {
                Console.WriteLine("StackList出栈值：{0}", client.PopItemFromList("StackList"));
            }
            Console.WriteLine("出栈完成");
            Console.ReadLine();
            #endregion
        }
        public static void SetRedis()//集合
        {
            #region Set操作
            client.AddItemToSet("QQ用户1", "好友A");
            client.AddItemToSet("QQ用户1", "好友B");
            client.AddItemToSet("QQ用户1", "好友C");
            client.AddItemToSet("QQ用户1", "好友D");

            client.AddItemToSet("QQ用户2", "好友C");
            client.AddItemToSet("QQ用户2", "好友F");
            client.AddItemToSet("QQ用户2", "好友G");
            client.AddItemToSet("QQ用户2", "好友D");
            var setunion = client.GetIntersectFromSets("QQ用户1", "QQ用户2");
            Console.WriteLine("QQ用户1和QQ用户2的共同好友为：");
            foreach (var item in setunion)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
            #endregion
        }
        public static void SortedSetRedis()//有序集合
        {
            #region Set操作
            client.AddItemToSortedSet("GiftSortedSet", "主播1", 24);
            client.AddItemToSortedSet("GiftSortedSet", "主播2", 564);
            client.AddItemToSortedSet("GiftSortedSet", "主播3", 746);
            client.AddItemToSortedSet("GiftSortedSet", "主播4", 2357);
            client.IncrementItemInSortedSet("GiftSortedSet", "主播2", new Random().Next(200, 500));
            Console.WriteLine("礼物数最多的前三名主播为：");
            foreach (var item in client.GetRangeWithScoresFromSortedSet("GiftSortedSet", 1, 3))
            {
                Console.WriteLine($"名：{item.Key} 分数：{item.Value}");
            }
            Console.ReadLine();
            #endregion
        }
    }
    public class Student
    {
        public int? Id { get; set; }
        public bool? Sex { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}





