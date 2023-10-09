//------------------------------------------------------------------------------------------------------------------------------------------------
namespace TBot_SDS.Tasks.GoToWebsiteTasks
{
    //------------------------------------------------------------------------------------------------------------------------------------------------
    public class GoToWebsiteCommand
    {
        public async Task GoToWebsite(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, SendMessage sendMessage, ConsoleMessage consoleMessage)
        {
            consoleMessage.SendingConsole(update.Message.Text, update.Message.Chat.Id);
            await sendMessage.SendingMessageAndPhoto(botClient, cancellationToken, update.Message.Chat.Id, GetText(), "ImgWebSite");

            var keyboardButtons = GetKeyboardButtons();
            var replyMarkup = new ReplyKeyboardMarkup(keyboardButtons) { ResizeKeyboard = true };
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, "🔜", replyMarkup: replyMarkup);
        }

        private string GetText()
        {
            return "\n\n▶️ Переходите по этой ссылке - https://a21208-7158.c.d-f.pw/.\n\n" +
                "Будем ждать вас!";
        }

        private KeyboardButton GetKeyboardButtons()
        {
            return new KeyboardButton("Меню");
        }
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------------
