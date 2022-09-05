using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._9_使用Monitor类锁定资源
{
    public class Player
    {
        public string Name { get; private set; }
        public int Atk { get; private set; }
        public Player(string name, int atk)
        {
            Name = name;
            Atk = atk;
        }
        public void Attack(YaoGuai yaoGuai)
        {
            while (yaoGuai.Blood > 0)
            {
                Console.WriteLine($"我是{Name},我来打妖怪,我打了{Atk}滴血");
                yaoGuai.BeAttacked(Atk);
            }
        }
    }
}
