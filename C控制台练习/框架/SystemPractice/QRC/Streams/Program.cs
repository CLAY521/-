using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streams
{
    class Program
    {
        static void Main(string[] args)
        {
            GZipStreams();
            Console.ReadKey();
        }



        #region System.IO   Two

        #region StreamReader   StreamWriter
        public static void StreamReader()
        {
            FileStream fs = new FileStream(@"E:\123.txt",FileMode.Open,FileAccess.Read);
            StreamReader sr = new StreamReader(fs);  //读取流
            Stream stream = sr.BaseStream;     //返回基础流
            //Console.WriteLine(stream.GetType());               //输出System.IO.FileStream
            //Console.WriteLine(sr.CurrentEncoding);               //当前流读取使用得编码
            //Console.WriteLine(sr.EndOfStream);               //知识当前流的位置是否在流的末尾

            string str = sr.ReadToEnd();       //对于不能使用length的流非常有用，比如压缩流   从当前位置读取到流的末尾
            Console.WriteLine("全部"+str);

            fs.Seek(3,SeekOrigin.Begin);         //便宜开始为3，UTF8,1个字节占用4个字符
            string str1 = sr.ReadLine();         //第一行文本
            Console.WriteLine("第一行"+str1);
            //Console.WriteLine("-----------------------------");
            //Console.WriteLine(sr.Peek());
            //Console.WriteLine("第一个字符："+Convert.ToChar(sr.Peek()));
            //Console.WriteLine("-----------------------------");


            //char[] chars = new char[10];
            //sr.Read(chars,0,10);         //将前11个字符读取到   字符数组(从0开始)
            //foreach (char c in chars)
            //{
            //    Console.WriteLine(c);
            //}
            //Console.WriteLine(Convert.ToChar(sr.Read()));    //将输出的数字转换为字符


            using (StreamReader sr1 = new StreamReader(@"E:\123.txt",Encoding.UTF8))
            {
                int s = 0;
                while ((s = sr1.Read()) != -1)               //读取完 s的值就是 -1
                {
                    Console.Write(Convert.ToChar(s));
                }
            }

            using (StreamReader sr3 = new StreamReader(@"E:\123.txt", Encoding.UTF8))
            {
                Console.WriteLine(Convert.ToChar(sr3.Peek()));         //输出文本的第一个字
            }

        }

        public static void StreamWrite()
        {
            StreamWriter sw = new StreamWriter(@"E:\123.txt");
            Console.WriteLine(sw.AutoFlush);      //是否每次调用sw后  将缓冲区刷新到基础流
            Console.WriteLine(sw.BaseStream.GetType());  
            Console.WriteLine(sw.Encoding);         
            Console.WriteLine(sw.FormatProvider);
            Console.WriteLine(sw.NewLine.ToString());   //获取或设置由当前 TextWriter 使用的行结束符字符串。 （继承自 TextWriter。）

            sw.WriteLine("123456123");
            sw.Flush();            //有缓冲区   要强制输出缓冲区内的数据，才真正显示

            sw.Write("测试测试测试");
            sw.Flush();

            sw.WriteLine("9999999");
            sw.Flush();
        }

        #endregion

        #region DeflateStream类   另外一种压缩、解压流
        public static void DeflateStreams()
        {

        }
        #endregion

        #region BufferedStream  缓冲流
        public static void BufferedStreams()
        {

        }
        #endregion

        #region GZipStream  压缩、解压流
        public static void GZipStreams()
        {
            
        }
        #endregion

        #region MemoryStream  内存流
        public static void MemoryStreams()
        {
            MemoryStream ms = new MemoryStream();
            Console.WriteLine(ms.Capacity);         //分配给该流的字节数
            byte[] b1 = Encoding.UTF8.GetBytes("fdfaasf");
            ms.Write(b1,0,b1.Length);
            Console.WriteLine(ms.Capacity);      //再次读取文本流分配的字节数
            Console.WriteLine(ms.Length);        //流的长度
            Console.WriteLine(ms.Position);      //流当前的位置



            byte[] b2 = ms.GetBuffer();    //返回无符号字节数组
            string str2 = Encoding.UTF8.GetString(b2);
            Console.WriteLine(str2);

            ms.Position = 0;
            ms.Seek(2,SeekOrigin.Current);//设置当前流正在读取的位置
            int i = ms.ReadByte();       //读取字节
            Console.WriteLine(i);
            byte[] b3 = ms.ToArray();
            foreach (byte b in b3)
            {
                Console.Write(b+"-");
            }


            //指定一个位置写入
            MemoryStream ms1 = new MemoryStream();
            byte[] bytesArr = Encoding.ASCII.GetBytes("abcdefg");
            ms1.Write(bytesArr,0,bytesArr.Length);
            ms1.Position = 2; ms1.WriteByte(97);    //将第二个C   替换成A  97
            string str = Encoding.ASCII.GetString(ms1.ToArray());
            Console.WriteLine(str);

            byte[] b6 = Encoding.ASCII.GetBytes("kk");        //将第四个E   替换成kk
            ms1.Position = 4;
            ms1.Write(b6,0,b6.Length);
            Console.WriteLine(Encoding.UTF8.GetString(ms1.ToArray()));
        }
        #endregion

        #region FileStream类
        public static void FileSteams()
        {
            
            using (FileStream fs = new FileStream(@"E:\123.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                Console.WriteLine(fs.CanRead);         //是否可以读取
                Console.WriteLine(fs.CanSeek);         //是否可以查找
                Console.WriteLine(fs.CanTimeout);      //是否可以超时
                Console.WriteLine(fs.CanWrite);        //是否可以写入
                Console.WriteLine(fs.IsAsync);         //是否是异步打开
                Console.WriteLine(fs.Length);          //获取用字节流表示的长度
                Console.WriteLine(fs.Position);        //获取和设置当前流的位置   此方法可赋值
                Console.WriteLine(fs.Name);            //获取传递给构造函数的文件名称
                                                       //Console.WriteLine(fs.ReadTimeout);     //多长时间后超时   读取
                                                       //Console.WriteLine(fs.WriteTimeout);    //多长时间后超时   写入

                //写入流
                string str = "你好吗？";
                byte[] bytes = Encoding.UTF8.GetBytes(str);
                fs.Write(bytes, 0, bytes.Length);
                fs.Flush();         //流会缓冲   此行代码指示流不要缓冲   立即写入文件



                //写入流，追加文本
                byte[] b0 = Encoding.UTF8.GetBytes("好像回家过年");
                fs.Write(b0, 0, b0.Length);
                fs.Flush();               //不缓冲数据     立即写入

                //写入流   逐个字符写入
                byte[] b1 = Encoding.UTF8.GetBytes("天意啊！");
                foreach (byte b in b1)
                {
                    fs.WriteByte(b);
                }
            }
            
            using (FileStream fs1 = new FileStream(@"E:\123.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                //读取内容
                byte[] b2 = new byte[fs1.Length];
                fs1.Read(b2, 0, b2.Length);
                Console.WriteLine(Encoding.UTF8.GetString(b2));
            }
            using (FileStream fs2 = new FileStream(@"E:\123.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                //逐个字符读取
                byte[] b3 = new byte[fs2.Length];
                for (int i = 0; i < b3.Length; i++)
                {
                    b3[i] = (byte)fs2.ReadByte();
                }
                Console.WriteLine(Encoding.UTF8.GetString(b3));
            }
        }
        #endregion

        #region FileAttributes枚举
        public static void FileAttribute()
        {
            File.SetAttributes(@"E:\file1.txt", FileAttributes.ReadOnly);
            FileAttributes f = File.GetAttributes(@"E:\file1.txt");
            if (f.ToString().Contains(FileAttributes.ReadOnly.ToString()))
            {
                Console.WriteLine("此文件是只读的");
            }
            else
            {
                Console.WriteLine("此文件不是只读的");
            }
        }

        #endregion

        #region File类和FileInfo类
        public static void FileClass()
        {
            File.AppendText(@"E:\file.txt");//创建file文本   固定式UTF-8编码   不可改变
            File.AppendAllText(@"E:\file1.txt","你在他乡还好吗？");//创建文本文件，并在里面写入内容
            //File.Copy(@"E:\file.txt",@"D:\file.txt",false);//复制文件
            File.Create(@"E:\123.txt");//创建文件   重载中可设置安全权限等信息
            Console.WriteLine(File.Exists(@"E:\file1.txt"));//是否存在此文件
            Console.WriteLine(File.GetCreationTime(@"E:\file1.txt"));//查看创建文件的时间
            Console.WriteLine(File.GetCreationTimeUtc(@"E\file1.txt"));//查看创建文件的   全球标准时间
            Console.WriteLine(File.GetLastAccessTime(@"E:\file1.txt"));//上次访问的时间
            Console.WriteLine(File.GetLastWriteTime(@"E:\file1.txt"));//上次写入的时间
            //File.Move("路径","路径1");          //将路径的文件移动到路径1
            byte[] byteArr = File.ReadAllBytes(@"E:\file1.txt");
            foreach (byte b in byteArr)
            {
                Console.Write(b+"\t");            //输出内容的没个字节    一串数字
            }

            string[] strArr = File.ReadAllLines(@"E:\file1.txt",Encoding.GetEncoding("GB2312"));  //对于中文，应该设置读取的变量为gb2312  或者  utf-8  否则中文都是问号
            foreach (string str in strArr)
            {
                Console.WriteLine(str);//一行就是一个字符串，所有行组成的字符串和数组
            }
            Console.WriteLine(File.ReadAllText(@"E:\file1.txt",Encoding.GetEncoding("Utf-8")));




            //可以设置访问时间和写入时间
            File.SetCreationTime(@"E:\file1.txt",DateTime.Now.AddDays(-1));
            Console.WriteLine(File.GetCreationTime(@"E:\file1.txt"));

            //File.WriteAllText(@"E:\file1.txt","真的爱你");//替换文本文件的内容

            //string[] strArr1 = { "你","好","吗","？"};
            //File.WriteAllLines(@"E:\file1.txt",strArr1);

            FileAttributes f = File.GetAttributes(@"E:\file1.txt");//获取当前文件的特性
            if ((f & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                Console.WriteLine("此文件是只读的");
            }
            else
            {
                Console.WriteLine("此文件不是只读的");
            }
            //设置文件属性，用标志枚举设置
            // File.SetAttributes(@"E:\file1.txt",FileAttributes.ReadOnly);//设置为只读
            //File.SetAttributes(@"E:\file1.txt", FileAttributes.Hidden | FileAttributes.ReadOnly);//位运算  同时设置隐藏与只读


            string xiang = "你在他乡还好吗？";
            byte[] bytes = Encoding.UTF8.GetBytes(xiang);
            File.WriteAllBytes(@"E:\file1.txt",bytes);

            //Open  已重载。 打开指定路径上的 FileStream。  方便了点，帮助new了FileStream而已，跟自己new FileStream一样
            FileStream fs = File.Open(@"E:\file1.txt",FileMode.Open,FileAccess.ReadWrite);
            byte[] byte1 = new byte[fs.Length];
            fs.Read(byte1,0,(int)fs.Length);
            Console.WriteLine(Encoding.UTF8.GetString(byte1));

            //FileStream fs2 = File.OpenWrite(@"E:\file1.txt");
            //byte[] byte2 = Encoding.UTF8.GetBytes("真的爱你o");
            //fs2.Write(byte2,0,byte2.Length);
            //fs2.Flush();

            //StreamWriter sw = File.CreateText(@"E:\kk.txt");
            //sw.Write("测试createtext方法");
            //sw.Flush();

            StreamReader sr = File.OpenText(@"E:\kk.txt");
            string str6 = sr.ReadToEnd();
            Console.WriteLine(str6);



            Console.WriteLine();
        }
        public static void FileInfoClass()
        {
            string path = Path.GetTempFileName();
            var fil = new FileInfo(path);
            using (StreamWriter sw = fil.CreateText())
            {
                sw.WriteLine("Hellow");
                sw.WriteLine("And");
                sw.WriteLine("Welcome");
            }
            using (StreamReader sr = fil.OpenText())
            {
                var s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }

            try
            {
                string path2 = Path.GetTempFileName();
                var fi2 = new FileInfo(path2);
                fi2.Delete();
                fil.CopyTo(path2);
                Console.WriteLine($"{path} was copied to {path2}");
                fi2.Delete();
                Console.WriteLine($"{path2} was successfully deleted");
            }
            catch (Exception e)
            {
                Console.WriteLine($"The process failed:{ e.ToString()}");
            }


        }
        #endregion

        #region System.IO.Path类
        public static void IOPath()
        {
            string str = "image/girl.jpg";
            string extend = Path.GetExtension(str);
            Console.WriteLine("文件的后缀名：" + extend);

            string str1 = @"C:\App_Data";
            string str2 = @"images\girl.jpg";
            string newPath = Path.Combine(str1, str2);
            Console.WriteLine("合并后的路径：" + newPath);

            string str3 = "image/girl.jpg";
            string newPath1 = Path.ChangeExtension(str3, "gif");
            Console.WriteLine("更改扩展名之后的路径为：" + str3);

            string str4 = @"C:\App_Data\images\girl.jpg";
            string dictory = Path.GetDirectoryName(str4);
            Console.WriteLine("输出给定路径字符串的目录信息：" + str4);

            string fileName = Path.GetFileName(str4);
            Console.WriteLine("路径中文件的全称" + fileName);

            string fileNameWithOutEntension = Path.GetFileNameWithoutExtension(str4);
            Console.WriteLine("路径中文件的名字（不包括扩展名）" + fileNameWithOutEntension);

            string str5 = @"/upload/girl.jpg";
            string fullPath = Path.GetFullPath(str);
            Console.WriteLine("绝对物理路径" + fullPath);

            char[] chArr = Path.GetInvalidFileNameChars();
            Console.WriteLine("输出很多不允许在文件名中使用得字符：");
            foreach (var c in chArr)
            {
                Console.Write(c + "");
            }

            char[] chArr1 = Path.GetInvalidPathChars();
            Console.WriteLine("输出很多不允许在路径中使用得字符：");
            foreach (var c in chArr1)
            {
                Console.Write(c + "");
            }


            string rootInfo = Path.GetPathRoot(str4);
            Console.WriteLine("输出路径的根目录" + rootInfo);

            string RandomFileName = Path.GetRandomFileName();
            Console.WriteLine("随机文件夹名或文件名" + RandomFileName);

            string fileZero = Path.GetTempFileName();
            Console.WriteLine("创建磁盘上唯一命名的零字节的临时文件并返回改文件的完整路径" + fileZero);

            string fileTemp = Path.GetTempPath();
            Console.WriteLine("输出临时文件所在的目录" + fileTemp);

            bool hasExtension = Path.HasExtension(str4);
            Console.WriteLine("检查路径是否含有扩展名，有返回true\t" + hasExtension);


            //其中   根指的是   C：   和    \
            string filename = @"C:\mydir\123.ext";
            Console.WriteLine("获取一个值，该值指示指定的路径字符串是否包含根。" + Path.IsPathRooted(filename));
            string uncPath = @"\\myPc\\mydir\\myfile";
            Console.WriteLine("获取一个值，该值指示指定的路径字符串是否包含根。" + Path.IsPathRooted(uncPath));
            string relativePath = @"mydir\sudir\";
            Console.WriteLine("获取一个值，该值指示指定的路径字符串是否包含根。" + Path.IsPathRooted(relativePath));


        }
        #endregion

        #endregion

        #region System.IO

        #region 删除文件夹和文件(创建文件夹)
        public static void DeleteDirectoryContentEx(string dirPath)
        {
            //目录中是否包含这个路径的文件
            if (Directory.Exists(dirPath))
            {

                foreach (string content in Directory.GetFileSystemEntries(dirPath))
                {
                    //删除文件夹
                    if (Directory.Exists(content))
                    {
                        Directory.Delete(content, true);
                    }
                    //删除文件
                    else if (File.Exists(content))
                    {
                        File.Delete(content);
                    }
                }
                //删除这个路径的文件（第二个参数，这个文件的子文件夹以及子文件）
                Directory.Delete(dirPath, true);
                //创建新的文件夹
                Directory.CreateDirectory(dirPath);
            }
        }

        public static void Delete(string filePath)
        {
            DirectoryInfo di = new DirectoryInfo(filePath);
            di.Delete(true);
        }
        #endregion

        #region 读取文件
        public static void GetStreamFile(string filePath)
        {
            Console.WriteLine("--{0}", "ReadAllLines");//字符串数组
            //读取路径下文件的内容(所有的行)
            string[] Str = File.ReadAllLines(filePath);
            for (int i = 0; i < Str.Length; i++)
            {
                Console.WriteLine(Str[i]);
            }
            Console.WriteLine("--{0}", "ReadLines");//集合
            List<string> list = new List<string>(File.ReadAllLines(filePath));
            list.ForEach(item =>
            {
                Console.WriteLine(item);
            });
            //所有的文本
            Console.WriteLine("--{0}", "ReadAlLText");//字符串
            string fileContent = File.ReadAllText(filePath);
            Console.WriteLine(fileContent);
            Console.WriteLine("--{0}", "StreamReader");//字节流
            using (StreamReader dr = new StreamReader(filePath))
            {
                Console.WriteLine("--{0}", "方法一");
                //方法一：从流的当前位置到末尾
                fileContent = string.Empty;
                fileContent = dr.ReadToEnd();
                Console.WriteLine(fileContent);
            }
        }
        #endregion

        #region 写入文件
        public static void WriteFile(string filePath)
        {
            //WriteAllLines
            //File.WriteAllLines(filePath, new string[] { "11111", "22222", "3333" });
            //File.Delete(filePath);

            //WriteAllText
            //File.WriteAllText(filePath, "11111\r\n22222\r\n3333\r\n");
            //File.Delete(filePath);

            //StreamWriter
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write("11111\r\n22222\r\n3333\r\n");
                sw.Flush();
            }
        }
        #endregion

        #region 文件路径的操作
        public static void FilePath()
        {
            string filePath = @"D:\TestDir\TestFile.txt";
            Console.WriteLine("<<<<<<<<<<<{0}>>>>>>>>>>", "文件路径");
            //获得当前路径
            Console.WriteLine(Environment.CurrentDirectory);
            //文件或文件夹所在目录
            Console.WriteLine(Path.GetDirectoryName(filePath));     //D:\TestDir

            //文件扩展名
            Console.WriteLine(Path.GetExtension(filePath));         //.txt
            //文件名
            Console.WriteLine(Path.GetFileName(filePath));          //TestFile.txt
            //绝对路径
            Console.WriteLine(Path.GetFullPath(filePath));          //D:\TestDir\TestFile.txt
            //更改扩展名
            Console.WriteLine(Path.ChangeExtension(filePath, ".jpg"));//D:\TestDir\TestFile.jpg
            //根目录
            //生成路径
            Console.WriteLine(Path.Combine(new string[] { @"D:\", "BaseDir", "SubDir", "TestFile.txt" })); //D:\BaseDir\SubDir\TestFile.txt
            //生成随即文件夹名或文件名
            Console.WriteLine(Path.GetRandomFileName());
            ////创建磁盘上唯一命名的零字节的临时文件并返回该文件的完整路径
            //Console.WriteLine(Path.GetTempFileName());
            ////返回当前系统的临时文件夹的路径
            //Console.WriteLine(Path.GetTempPath());
            ////文件名中无效字符
            //Console.WriteLine(Path.GetInvalidFileNameChars());
            ////路径中无效字符
            //Console.WriteLine(Path.GetInvalidPathChars());
        }
        #endregion

        #endregion

    }

    #region  FileAttributes
    //public enum FileAttributes
    //{
    //    // 摘要:
    //    //     文件为只读。
    //    ReadOnly = 1,
    //    //
    //    // 摘要:
    //    //     文件是隐藏的，因此没有包括在普通的目录列表中。
    //    Hidden = 2,
    //    //
    //    // 摘要:
    //    //     文件为系统文件。文件是操作系统的一部分或由操作系统以独占方式使用。
    //    System = 4,
    //    //
    //    // 摘要:
    //    //     文件为一个目录。
    //    Directory = 16,
    //    //
    //    // 摘要:
    //    //     文件的存档状态。应用程序使用此属性为文件加上备份或移除标记。
    //    Archive = 32,
    //    //
    //    // 摘要:
    //    //     保留供将来使用。
    //    Device = 64,
    //    //
    //    // 摘要:
    //    //     文件正常，没有设置其他的属性。此属性仅在单独使用时有效。
    //    Normal = 128,
    //    //
    //    // 摘要:
    //    //     文件是临时文件。文件系统试图将所有数据保留在内存中以便更快地访问，而不是将数据刷新回大容量存储器中。不再需要临时文件时，应用程序会立即将其删除。
    //    Temporary = 256,
    //    //
    //    // 摘要:
    //    //     文件为稀疏文件。稀疏文件一般是数据通常为零的大文件。
    //    SparseFile = 512,
    //    //
    //    // 摘要:
    //    //     文件包含一个重新分析点，它是一个与文件或目录关联的用户定义的数据块。
    //    ReparsePoint = 1024,
    //    //
    //    // 摘要:
    //    //     文件已压缩。
    //    Compressed = 2048,
    //    //
    //    // 摘要:
    //    //     文件已脱机。文件数据不能立即供使用。
    //    Offline = 4096,
    //    //
    //    // 摘要:
    //    //     操作系统的内容索引服务不会创建此文件的索引。
    //    NotContentIndexed = 8192,
    //    //
    //    // 摘要:
    //    //     该文件或目录是加密的。对于文件来说，表示文件中的所有数据都是加密的。对于目录来说，表示新创建的文件和目录在默认情况下是加密的。
    //    Encrypted = 16384
    //}
    #endregion

    #region FileMode
    //public enum FileMode
    //{
    //    // 摘要:
    //    //     指定操作系统应创建新文件。此操作需要 System.Security.Permissions.FileIOPermissionAccess.Write。如果文件已存在，则将引发
    //    //     System.IO.IOException。
    //    CreateNew = 1,
    //    //
    //    // 摘要:
    //    //     指定操作系统应创建新文件。如果文件已存在，它将被覆盖。此操作需要 System.Security.Permissions.FileIOPermissionAccess.Write。System.IO.FileMode.Create
    //    //     等效于这样的请求：如果文件不存在，则使用 System.IO.FileMode.CreateNew；否则使用 System.IO.FileMode.Truncate。如果该文件已存在但为隐藏文件，则将引发
    //    //     System.UnauthorizedAccessException。
    //    Create = 2,
    //    //
    //    // 摘要:
    //    //     指定操作系统应打开现有文件。打开文件的能力取决于 System.IO.FileAccess 所指定的值。如果该文件不存在，则引发 System.IO.FileNotFoundException。
    //    Open = 3,
    //    //
    //    // 摘要:
    //    //     指定操作系统应打开文件（如果文件存在）；否则，应创建新文件。如果用 FileAccess.Read 打开文件，则需要 System.Security.Permissions.FileIOPermissionAccess.Read。如果文件访问为
    //    //     FileAccess.Write，则需要 System.Security.Permissions.FileIOPermissionAccess.Write。如果用
    //    //     FileAccess.ReadWrite 打开文件，则同时需要 System.Security.Permissions.FileIOPermissionAccess.Read
    //    //     和 System.Security.Permissions.FileIOPermissionAccess.Write。如果文件访问为 FileAccess.Append，则需要
    //    //     System.Security.Permissions.FileIOPermissionAccess.Append。
    //    OpenOrCreate = 4,
    //    //
    //    // 摘要:
    //    //     指定操作系统应打开现有文件。文件一旦打开，就将被截断为零字节大小。此操作需要 System.Security.Permissions.FileIOPermissionAccess.Write。尝试从使用
    //    //     Truncate 打开的文件中进行读取将导致异常。
    //    Truncate = 5,
    //    //
    //    // 摘要:
    //    //     若存在文件，则打开该文件并查找到文件尾，或者创建一个新文件。FileMode.Append 只能与 FileAccess.Write 一起使用。尝试查找文件尾之前的位置时会引发
    //    //     System.IO.IOException，并且任何尝试读取的操作都会失败并引发 System.NotSupportedException。
    //    Append = 6,
    //}
    #endregion

    #region FileAccess 
    //public enum FileAccess
    //{
    //    // 摘要:
    //    //     对文件的读访问。可从文件中读取数据。同 Write 组合即构成读写访问权。
    //    Read = 1,
    //    //
    //    // 摘要:
    //    //     文件的写访问。可将数据写入文件。同 Read 组合即构成读/写访问权。
    //    Write = 2,
    //    //
    //    // 摘要:
    //    //     对文件的读访问和写访问。可从文件读取数据和将数据写入文件。
    //    ReadWrite = 3,
    //}
    #endregion
}
