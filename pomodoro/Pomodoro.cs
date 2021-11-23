using System;
using System.Timers;
namespace pomodoro_cli
{
    class Pomodoro{

        private Timer timer;
        private string topic;

        private long ticksRemaining = (1 * TimeSpan.TicksPerMinute) - TimeSpan.TicksPerSecond;

        public Pomodoro(Timer timer, string topic)
        {
            this.timer = timer;
            this.topic = topic;
        }

        public void Run()
        {
            Console.WriteLine($"Beginning Pomodoro for {topic}");
            Start();
            Console.ReadKey();
            Stop();
        }

        private void Start()
        {
            timer.Elapsed += OnTick;
            timer.Interval = 1000;
            timer.AutoReset = true;
            timer.Enabled = true;
            
        }

        private void Stop()
        {
            timer.Stop();
            timer.Dispose();
        }

        private void OnTick(Object source, ElapsedEventArgs e)
        {
            if (ticksRemaining < TimeSpan.TicksPerSecond)
            {
                Console.WriteLine("\rFinished!");
                Stop();
            }
            else
            {
                var timeSpan = new TimeSpan(ticksRemaining);
                Console.Write($"\r{timeSpan.Minutes}:{timeSpan.Seconds}");
                ticksRemaining = ticksRemaining - TimeSpan.TicksPerSecond;
            }
        }
    }
}