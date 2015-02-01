using System;
using System.Threading;
namespace S01
{
	public class Timer
	{
		public Action<int> Tick { get; set; }
		public void Start()
		{
			int time=0;
			while(true)
			{
				Tick(time++);
				Thread.Sleep(1000);
			}
		}
	}
	
	class Program
	{
		public static void MainX()
		{
			var timer=new Timer();
			timer.Tick=z=>Console.WriteLine(z);
			timer.Tick(100);
			timer.Start ();
		}	
	}	
}

//! Что такое событие? Сначала поймем, что такое делегат - ссылка на функцию. Action<int> - ссылка на фунцкию, обрабатывающую int
//! Я использую lambda-синтаксис: это то же самое, что определить метод и сослаться на него. Но это короче, и когда в программе 100 мелких обработчиков, это удобно.
//! Но делегат - небезопасен: если его можно установить, значит, можно и вызвать.