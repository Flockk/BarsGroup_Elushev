namespace Threading
{
    internal class Program
    {
        static void Main()
        {

            DummyRequestHandler dummyRequest = new();
            string[] arguments;
            List<string> argList = new();
            string args = "...";

            Console.WriteLine("Введите текст запроса для отправки. Для выхода введите /exit");
            var command = Console.ReadLine();
            while (command != "/exit")
            {
                while (args != "/end")
                {
                    Console.WriteLine("Введите аргументы сообщения. Если аргументы не нужны - введите /end");
                    args = Console.ReadLine();
                    argList.Add(args);
                }
                argList.Remove("/end");
                arguments = argList.ToArray();
                ThreadPool.QueueUserWorkItem(callBack => Write(command, arguments));
                Console.WriteLine($"Было отправлено сообщение '{command }'");
                Console.WriteLine("Введите текст запроса для отправки. Для выхода введите /exit");
                args = "...";
                argList.Clear();
                command = Console.ReadLine();
            }
            Console.WriteLine("Работа завершена!");
        }

        static void Write(string command, string[] arguments)
        {

            try
            {
                var result = new DummyRequestHandler().HandleRequest(command!, arguments);
                Console.WriteLine($"Сообщение с идентификатром '{command }' получило ответ: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}