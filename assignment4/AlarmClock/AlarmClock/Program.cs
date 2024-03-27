using System;

namespace AlarmClockExample
{
    // 定义闹钟类
    public class AlarmClock
    {
        // 定义嘀嗒事件
        public event EventHandler Tick;
        // 定义响铃事件
        public event EventHandler Alarm;

        // 定时器用于模拟嘀嗒声
        private Timer tickTimer;
        // 闹钟响铃的时间
        private DateTime alarmTime;

        // 构造函数，设置闹钟响铃时间
        public AlarmClock(DateTime alarmTime)
        {
            this.alarmTime = alarmTime;
            tickTimer = new Timer(TickTock, null, 1000, 1000); // 每秒触发一次
        }

        // 嘀嗒方法，触发Tick事件
        protected virtual void OnTick()
        {
            Tick?.Invoke(this, EventArgs.Empty);
            Console.WriteLine("Tick...");
        }

        // 定时器的回调方法
        private void TickTock(object state)
        {
            DateTime now = DateTime.Now;
            if (now >= alarmTime)
            {
                // 如果当前时间到了设定的闹钟时间，触发Alarm事件
                Alarm?.Invoke(this, EventArgs.Empty);
                Console.WriteLine("Alarm!");
                tickTimer.Dispose(); // 停止定时器
            }
            else
            {
                OnTick(); // 继续嘀嗒
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 创建闹钟实例，设置响铃时间为5秒后
            AlarmClock alarmClock = new AlarmClock(DateTime.Now.AddSeconds(5));

            // 订阅Tick事件
            alarmClock.Tick += (sender, e) => Console.WriteLine("Tick 事件被触发");

            // 订阅Alarm事件
            alarmClock.Alarm += (sender, e) => Console.WriteLine("Alarm 事件被触发");

            // 等待闹钟响起
            Console.WriteLine("等待闹钟响起...");
            Console.ReadKey();
        }
    }
}