using System;
using System.Linq;
using osuDifficultyIPC.LegacyIpc;

namespace osuDifficultyIPC
{
    public class Program
    {
        private static bool exit;
        public static int Main(string[] args)
        {
            Console.Title = "osuDifficultyIPC: Starting";
            Console.WriteLine("Starting legacy IPC provider...");

            bool debug = args.Contains("-d") || args.Contains("--debug");
            var legacyIpc = new LegacyTcpIpcProvider(debug);
            bool bindResult = legacyIpc.Bind();
            if (!bindResult)
            {
                Console.Title = "osuDifficultyIPC: Failed";
                Console.WriteLine("Failed to start server.");
                return 1;
            }

            Console.Title = "osuDifficultyIPC: Started | CTRL + C to stop";
            Console.WriteLine("Server started! Press CTRL + C to stop.");
            Console.CancelKeyPress += new ConsoleCancelEventHandler(exitHandler);

            // Just sleep until CTRL + C
            while (!exit) { }
            legacyIpc.Dispose();

            return 0;
        }

        public static void exitHandler(object sender, ConsoleCancelEventArgs args)
        {
            args.Cancel = true;
            exit = true;
        }
    }
}