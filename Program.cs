using System;

namespace pomodoro_cli
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidateArgs(args);
            var topic = ParseArgs(args);
            var timer = new System.Timers.Timer();
            var pomodoro =  new Pomodoro(timer, topic);
            pomodoro.Run();
        }

        private static void ValidateArgs(string[] args)
        {
            if (args.Length != 1) {
                throw new Exception("Error: Include only one argument!");
            }
        }

        private static String ParseArgs(string[] args)
        {
            return Convert.ToString(args[0]);
        }
    }
}
