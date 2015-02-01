using System;
using System.Threading;

namespace S04
{
	public class TimerEventArgs : EventArgs 
	{
		public int Time { get; set; }
	}
	
	public delegate void TimerEventHandler(object sender, TimerEventArgs args);
	
	public class Timer
	{
		public event TimerEventHandler Tick;
		
		protected virtual void OnTick(int time)
		{
			if (Tick!=null) 
				Tick(this,new TimerEventArgs { Time=time });
		}
		
		public void Start()
		{
			int time=0;
			while(true)
			{
				OnTick(time++);
				Thread.Sleep(1000);
			}
		}
	}
	
	class Program
	{
		static void OldHandler(object sender, EventArgs args)
		{
			Console.WriteLine ("Something happened");
		}
		
		static void NewHandler(object sender, TimerEventArgs args)
		{
			Console.WriteLine ("Timer ticked {0}",args.Time);
			
		}
		
		public static void MainX()
		{
			var timer=new Timer();
			timer.Tick += OldHandler;
			timer.Tick+=NewHandler;
			timer.Start ();
		}	
	}	
}

//!Полный синтаксис события: так нужно писать по рекомендациям Microsoft. 