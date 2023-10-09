//------------------------------------------------------------------------------------------------------------------------------------------------
namespace TBot_SDS.Tasks.SiteDevelopmentCommandTasks
{
    //------------------------------------------------------------------------------------------------------------------------------------------------
    public class SiteDevelopmentCommand
    {
        public async Task SiteDevelopment(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, SendMessage sendMessage, ConsoleMessage consoleMessage)
        {
            consoleMessage.SendingConsole(update.Message.Text, update.Message.Chat.Id);
            await sendMessage.SendingMessageAndPhoto(botClient, cancellationToken, update.Message.Chat.Id, GetText(), "ImgSiteDevelopment");

            var keyboardButtons = GetKeyboardButtons();
            var replyMarkup = new ReplyKeyboardMarkup(keyboardButtons) { ResizeKeyboard = true };
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, "🔜", replyMarkup: replyMarkup);
        }

        private string GetText()
        {
            return "🌌 Мы - креативная веб-разработческая компания, специализирующаяся на создании качественных и современных сайтов.\n\n" +
                "🌌 Наша команда состоит из талантливых профессионалов, которые страстно увлечены веб-технологиями и следят за последними трендами в веб-дизайне и разработке.\n\n" +
                "🌌 Мы понимаем, что ваш сайт - это лицо вашего бизнеса в онлайн-мире, поэтому мы стремимся создать уникальные веб-проекты, которые отражают вашу уникальность и ценности.\n\n" +
                "🌌 Мы уделяем особое внимание деталям, эстетике и пользовательскому опыту, чтобы создать сайт, который эффективно коммуницирует с вашей аудиторией и позволяет достичь ваших целей в онлайн-среде.\n\n" +
                "🌌 Мы разрабатываем сайты различной сложности и функциональности - от корпоративных сайтов и интернет-магазинов до персональных портфолио и блогов.\n\n" +
                "🌌 Примером является наш сайт (кнопка перейти на сайт).";
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
