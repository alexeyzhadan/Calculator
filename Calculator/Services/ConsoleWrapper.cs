using Calculator.Services.Interfaces;
using System;

namespace Calculator.Services
{
    public class ConsoleWrapper : IConsole
    {
        public string ReadLine()
            => Console.ReadLine();

        public void WriteLine(string value)
            => Console.WriteLine(value);
    }
}