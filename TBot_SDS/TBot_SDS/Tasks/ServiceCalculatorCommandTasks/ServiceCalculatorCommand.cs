//------------------------------------------------------------------------------------------------------------------------------------------------
namespace TBot_SDS.Tasks.ServiceCalculatorCommandTasks
{
    //------------------------------------------------------------------------------------------------------------------------------------------------
    public class ServiceCalculatorCommand
    {
        public async Task ServiceCalculator(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, SendMessage sendMessage, ConsoleMessage consoleMessage)
        {
            consoleMessage.SendingConsole(update.Message.Text, update.Message.Chat.Id);
            await sendMessage.SendingMessageAndPhoto(botClient, cancellationToken, update.Message.Chat.Id, GetText(), "ImgServiceCalculator");

            var keyboardButtons = GetKeyboardButtons();
            var replyMarkup = new ReplyKeyboardMarkup(keyboardButtons) { ResizeKeyboard = true };
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, "🔜", replyMarkup: replyMarkup);
        }
        private string GetText()
        {
            return "❌ Данный раздел находится в разработке...";
        }

        private KeyboardButton[] GetKeyboardButtons()
        {
            return new[]
            {
                new KeyboardButton("Назад"),
                new KeyboardButton("Перейти на сайт"),
                new KeyboardButton("Контакты")
            };
        }
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------------
