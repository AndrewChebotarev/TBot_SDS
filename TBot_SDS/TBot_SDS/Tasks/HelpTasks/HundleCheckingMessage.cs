namespace TBot_SDS.Tasks.HelpTasks
{
    public class HundleCheckingMessage
    {
        public bool CheckingForMessage(Update update)
        {
            if (update.Message is not { } message)
                return false;

            if (message.Text is not { } messageText)
                return false;

            return true;
        }
    }
}
