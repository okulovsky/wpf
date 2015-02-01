using System;
using System.Threading;

namespace S03
{
	public class Timer
	{

		public event Action<int> Tick;
		
		public void Start()
		{
			int time=0;
			while(true)
			{
				Tick(time++);
				Thread.Sleep(Interval);
			}
		}

        public int Interval { get; set; }
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

//! Чаще всего, событие пишут автосинтаксисом (также, как и свойства). Но важно понимать, что это по-прежнему пара методов, и компилятор автоматически создает поле-делегат.
