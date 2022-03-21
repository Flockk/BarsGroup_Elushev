using System;


namespace Events
{
    class Program
    {
        public static void Main()
        {
            var key = new KeyTest();
            key.OnKeyPressed += (Sender, PressKey) => Console.WriteLine($"\nВведённый символ: {PressKey}");
            key.Run();

        }
    }

    internal class KeyTest
    {
        public event EventHandler<char> OnKeyPressed;

        public void Run()
        {
            while (true)
            {
                Console.Write("Введите символ: ");
                var symbol = Console.ReadKey();
                if (symbol.Key == ConsoleKey.C)
                {
                    break;
                }
                else
                {
                    OnKeyPressed?.Invoke(this, symbol.KeyChar);
                }
                Console.WriteLine("");
            }
        }
    }
}
