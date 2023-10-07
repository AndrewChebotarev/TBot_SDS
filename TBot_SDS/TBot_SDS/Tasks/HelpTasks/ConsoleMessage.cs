namespace TBot_SDS.Tasks.HelpTasks
{
    public class ConsoleMessage
    {
        public void SendingConsole(string text, long id) => Console.WriteLine($"Пришел текст: {text} от пользователя с id: {id}");
    }
}