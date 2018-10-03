using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank(2, "Bubon", 150);
            bank.Money = 5;
        }
    }
}
