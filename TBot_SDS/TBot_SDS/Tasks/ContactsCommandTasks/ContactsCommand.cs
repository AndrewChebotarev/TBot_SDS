//------------------------------------------------------------------------------------------------------------------------------------------------
namespace TBot_SDS.Tasks.ContactsCommandTasks
{
    //------------------------------------------------------------------------------------------------------------------------------------------------
    public class ContactsCommand
    {
        public async Task Contacts(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, SendMessage sendMessage, ConsoleMessage consoleMessage)
        {
            consoleMessage.SendingConsole(update.Message.Text, update.Message.Chat.Id);
            await sendMessage.SendingMessageAndPhoto(botClient, cancellationToken, update.Message.Chat.Id, GetText(), "ImgContacts");

            var keyboardButtons = GetKeyboardButtons();
            var replyMarkup = new ReplyKeyboardMarkup(keyboardButtons) { ResizeKeyboard = true };
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, "🔜", replyMarkup: replyMarkup);
        }

        private string GetText()
        {
            return "Наши контакты:\n\n" +
                "✅ Наш сайт - https://a21336-ae42.g.d-f.pw/.\n" +
                "✅ Вк - https://vk.com/sokolov_development_studio\n" +
                "✅ Телефоны - +79155420014, +79092102324\n\n" +
                "Ответим мгновенно! Ждем вас!";
        }

        private KeyboardButton GetKeyboardButtons()
        {
            return new KeyboardButton("Меню");
        }
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------------
