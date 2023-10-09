//------------------------------------------------------------------------------------------------------------------------------------------------
namespace TBot_SDS.Tasks.StartCommandTasks
{
    //------------------------------------------------------------------------------------------------------------------------------------------------
    public class StartCommand
    {
        public async Task Start(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, SendMessage sendMessage, ConsoleMessage consoleMessage)
        {
            consoleMessage.SendingConsole(update.Message.Text, update.Message.Chat.Id);
            await sendMessage.SendingMessageAndPhoto(botClient, cancellationToken, update.Message.Chat.Id, GetText(), "ImgMenu");

            var keyboardButtons = GetKeyboardButtons();
            var replyMarkup = new ReplyKeyboardMarkup(keyboardButtons) { ResizeKeyboard = true };
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, "🔜", replyMarkup: replyMarkup);
        }

        private string GetText()
        {
            return "Очень рады вас видеть! \n" +
                "\n" +
                "Выберите в меню, что вас интересует:\n" +
                "\n" +
                "✅ /Novel - Создание новелл \n" +
                "✅ /GameCreation - Создание игр \n" +
                "✅ /GameConstructor - Конструктор игр \n" +
                "✅ /SiteDevelopment - Разработка сайта \n" +
                "✅ /DevelopmentTelegramBOT - Разработка Telegram BOT \n" +
                "✅ /SoftwareDevelopment - Разработка ПО \n" +
                "✅ /DesignServices - Услуги дизайна \n" +
                "✅ /ServiceCalculator - Калькулятор услуг \n" +
                "✅ /Contacts - Контакты \n" +
                "\n\n" +
                "Обращайтесь по любым вопросам!";
        }

        private KeyboardButton[][] GetKeyboardButtons()
        {
            return new[]
            {
                new[]
                {
                    new KeyboardButton("Создание новелл"),
                    new KeyboardButton("Создание игр"),
                    new KeyboardButton("Конструктор игр")
                },
                new[]
                {
                    new KeyboardButton("Разработка сайта"),
                    new KeyboardButton("Разработка Telegram BOT"),
                    new KeyboardButton("Разработка ПО")
                },
                new[]
                {
                    new KeyboardButton("Услуги дизайна"),
                    new KeyboardButton("Калькулятор услуг"),
                    new KeyboardButton("Контакты")
                }
            };
        }
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------------
