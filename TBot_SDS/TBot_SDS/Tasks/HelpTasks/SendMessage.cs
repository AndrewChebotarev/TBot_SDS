namespace TBot_SDS.Tasks.HelpTasks
{
    public class SendMessage
    {
        public async Task SendingMessage(ITelegramBotClient botClient, CancellationToken cancellationToken, long id, string text)
        {
            Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: id,
                text: text,
                cancellationToken: cancellationToken);
        }

        public async Task SendingMessageAndPhoto(ITelegramBotClient botClient, CancellationToken cancellationToken, long id, string text)
        {
            string PhotoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Prigozhin.jpg");

            using (var fileStream = new FileStream(PhotoPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Message message = await botClient.SendPhotoAsync(
                    chatId: id,
                    photo: new InputFileStream(fileStream),
                    caption: text,
                    cancellationToken: cancellationToken);
            }
        }
    }
}
