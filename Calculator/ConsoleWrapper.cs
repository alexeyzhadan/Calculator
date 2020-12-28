using Calculator.Interfaces;
using System;

namespace Calculator
{
    public class ConsoleWrapper : IConsole
    {
        public string ReadLine()
            => Console.ReadLine();

        public void WriteLine(string value)
            => Console.WriteLine(value);
    }
}