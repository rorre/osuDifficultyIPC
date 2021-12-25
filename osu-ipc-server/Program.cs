using System;
using System.Collections.Generic;
using System.Linq;
using osuDifficultyIPC.LegacyIpc;

namespace osuDifficultyIPC // Note: actual namespace depends on the project name.
{
    public class Program
    {
        private static bool exit;
        public static void Main(string[] args)
        {
            Console.WriteLine("Starting legacy IPC provider...");
            var legacyIpc = new LegacyTcpIpcProvider();
            legacyIpc.Bind();

            Console.CancelKeyPress += new ConsoleCancelEventHandler(exitHandler);
            while (!exit) { }
            legacyIpc.Dispose();
        }

        public static void exitHandler(object sender, ConsoleCancelEventArgs args)
        {
            args.Cancel = true;
            exit = true;
        }
    }
}