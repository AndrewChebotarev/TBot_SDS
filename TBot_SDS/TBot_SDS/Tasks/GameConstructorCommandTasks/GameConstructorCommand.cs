//------------------------------------------------------------------------------------------------------------------------------------------------
namespace TBot_SDS.Tasks.GameConstructorCommandTasks
{
    //------------------------------------------------------------------------------------------------------------------------------------------------
    public class GameConstructorCommand
    {
        public async Task GameConstructor(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, SendMessage sendMessage, ConsoleMessage consoleMessage)
        {
            consoleMessage.SendingConsole(update.Message.Text, update.Message.Chat.Id);
            await sendMessage.SendingMessageAndPhoto(botClient, cancellationToken, update.Message.Chat.Id, GetText(), "ImgGameConstructor");

            var keyboardButtons = GetKeyboardButtons();
            var replyMarkup = new ReplyKeyboardMarkup(keyboardButtons) { ResizeKeyboard = true };
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, "🔜", replyMarkup: replyMarkup);
        }
        private string GetText()
        {
            return "🏗 Мы представляем наш инновационный игровой движок, специально разработанный для создания захватывающих визуальных новел.\n\n" +
                "🏗 Наша команда разработчиков собрала все свои знания и опыт, чтобы предоставить вам мощный инструмент, который поможет воплотить ваши творческие идеи в жизнь.\n\n" +
                "🏗 Наш игровой движок обладает простым и интуитивным интерфейсом, что делает его доступным даже для новичков в области разработки игр. \n\n" +
                "🏗 Вы сможете создавать красочные сцены, управлять геймплеем, настраивать персонажей и диалоги, а также взаимодействовать с различными элементами в игре.\n\n" +
                "🏗 О данной игровом движке вы можете ознакомится на нашем сайте (кнопка перейти на сайт).\n\n" +
                "🏗 На данный момент игровой движок в разработке!";
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
