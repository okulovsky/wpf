using System;
using System.Threading;

namespace S02
{
	public class Timer
	{
        Action<int> tick;
		
		public event Action<int> Tick
		{
			add { tick+=value; }
			remove { tick-=value; }
		}
		
		public void Start()
		{
			int time=0;
			while(true)
			{
				// Tick(time++); //ошибка: невозможно вызвать event
				tick(time++);
				Thread.Sleep(interval);
			}
		}

        int interval;
        public int Interval
        {
            get { return interval; }
            set { interval = value; }
        }
	}
	
	class Program
	{
		public static void MainX()
		{
			var timer=new Timer();
            timer.Interval = 1000;
			timer.Tick += z=>Console.WriteLine(z);
			//timer.Tick(100); //ошибка: невозможно вызвать event
			timer.Start ();
		}	
	}	
}

//!Событие есть обертка над делегатом - подобно тому, как свойство есть обертка над полем. Это пара методов, add и remove.