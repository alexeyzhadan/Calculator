namespace Calculator.Services.Interfaces
{
    public interface IConsole
    {
        void WriteLine(string message);
        string ReadLine();
    }
}