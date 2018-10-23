using System;
namespace AzureD365DemoWebJob.Utils
{
    public static class ConsoleHelper
    {
        public static void DrawTextProgressBar(string stepDescription, int progress, int total)
        {
            var totalChunks = 30;

            //draw empty progress bar
            Console.CursorLeft = 0;
            Console.Write("["); //start
            Console.CursorLeft = totalChunks + 1;
            Console.Write("]"); //end
            Console.CursorLeft = 1;

            var pctComplete = Convert.ToDouble(progress) / total;
            var numChunksComplete = Convert.ToInt16(totalChunks * pctComplete);

            //draw completed chunks
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("".PadRight(numChunksComplete));

            //draw incomplete chunks
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write("".PadRight(totalChunks - numChunksComplete));

            //draw totals
            Console.CursorLeft = totalChunks + 5;
            Console.BackgroundColor = ConsoleColor.Black;

            var output = progress + " / " + total + " - ";
            Console.Write(output.PadRight(15) + stepDescription); //pad the output so when changing from 3 to 4 digits we avoid text shifting
        }

        public static void Log(string message, LogStatus status = LogStatus.Standard, bool addTimeStamp = false, bool withoutReturn = false)
        {
            switch (status)
            {
                case LogStatus.Standard:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogStatus.Verbose:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
                case LogStatus.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogStatus.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogStatus.Information:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    break;
                case LogStatus.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    break;
            }

            if (addTimeStamp)
            {
                message = $"[{DateTime.Now:yyyy-MM-dd hh:mm:ss}] - " + message;
            }

            if (!withoutReturn)
                Console.WriteLine(message);
            else
                Console.Write(message + " : ");

            Console.ResetColor();
        }


        public enum LogStatus
        {
            Standard,
            Verbose,
            Information,
            Warning,
            Error,
            Success
        }
    }
}
