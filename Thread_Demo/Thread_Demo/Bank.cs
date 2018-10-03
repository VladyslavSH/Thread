using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Demo
{
    public class Bank
    {
        private int _money;
        private string _name = null;
        private int _percent;
        public Bank()
        {

        }
        public Bank(int money, string name, int percent)
        {
            Money = money;
            Name = name;
            Percent = percent;
        }
        public int Money {
            get
            {
                return _money;
            }
            set
            {
                _money = value;
                Thread thread = new Thread(new ThreadStart(method));
                thread.Start();
            }
        }

        public string Name {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                Thread thread = new Thread(new ThreadStart(method));
                thread.Start();
            }
        }

        public int Percent {
            get
            {
                return _percent;
            }
            set
            { _percent = value;
                Thread thread = new Thread(new ThreadStart(method));
                thread.Start();
            }
        }
        private void method()
        {
            lock (this) {
                File.WriteAllText("file.txt", $"Money = {_money}, name = {_name}, percent = {_percent}");
            }
        }
    }
}
