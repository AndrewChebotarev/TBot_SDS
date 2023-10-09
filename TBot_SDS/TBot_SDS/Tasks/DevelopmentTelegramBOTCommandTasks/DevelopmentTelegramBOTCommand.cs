//------------------------------------------------------------------------------------------------------------------------------------------------
namespace TBot_SDS.Tasks.DevelopmentTelegramBOTCommandTasks
{
    //------------------------------------------------------------------------------------------------------------------------------------------------
    public class DevelopmentTelegramBOTCommand
    {
        public async Task DevelopmentTelegramBOT(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, SendMessage sendMessage, ConsoleMessage consoleMessage)
        {
            consoleMessage.SendingConsole(update.Message.Text, update.Message.Chat.Id);
            await sendMessage.SendingMessageAndPhoto(botClient, cancellationToken, update.Message.Chat.Id, GetText(), "ImgDevelopmentTelegramBOT");

            var keyboardButtons = GetKeyboardButtons();
            var replyMarkup = new ReplyKeyboardMarkup(keyboardButtons) { ResizeKeyboard = true };
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, "🔜", replyMarkup: replyMarkup);
        }
        private string GetText()
        {
            return "👩‍🚀 Мы — инновационная компания, специализирующаяся на разработке современных и мощных телеграм-ботов.\n\n" +
                "👩‍🚀 Наша команда состоит из опытных разработчиков и инженеров, которые страстно увлечены возможностями, которые предоставляет Telegram API, и готовы превратить ваши идеи в инновационные боты с высокой функциональностью.\n\n" +
                "👩‍🚀 Мы понимаем, что телеграм-боты стали все более популярными для бизнеса и личного использования.\n\n" +
                "👩‍🚀 Поэтому мы стремимся создавать высококачественные и интуитивно понятные боты, которые помогут нашим клиентам повысить эффективность своего бизнеса, автоматизировать рутинные задачи и обеспечить более эффективное взаимодействие с клиентами и пользователем.\n\n" +
                "👩‍🚀 Наши боты разрабатываются с применением передовых технологий и позволяют интегрировать различные функции, такие как обработка команд, отправка сообщений, работа с базой данных, интеграция с внешними сервисами и многое другое.\n\n" +
                "👩‍🚀 Примером является - данный телеграм бот!";
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
