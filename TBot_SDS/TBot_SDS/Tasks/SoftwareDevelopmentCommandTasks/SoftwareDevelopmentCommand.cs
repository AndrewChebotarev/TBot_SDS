//------------------------------------------------------------------------------------------------------------------------------------------------
namespace TBot_SDS.Tasks.SoftwareDevelopmentCommandTasks
{
    //------------------------------------------------------------------------------------------------------------------------------------------------
    public class SoftwareDevelopmentCommand
    {
        public async Task SoftwareDevelopment(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, SendMessage sendMessage, ConsoleMessage consoleMessage)
        {
            consoleMessage.SendingConsole(update.Message.Text, update.Message.Chat.Id);
            await sendMessage.SendingMessageAndPhoto(botClient, cancellationToken, update.Message.Chat.Id, GetText(), "ImgSoftwareDevelopment");

            var keyboardButtons = GetKeyboardButtons();
            var replyMarkup = new ReplyKeyboardMarkup(keyboardButtons) { ResizeKeyboard = true };
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, "🔜", replyMarkup: replyMarkup);
        }
        private string GetText()
        {
            return "🛠 Мы — ведущая компания в области разработки программного обеспечения, с глубокими знаниями и большим опытом в создании инновационных решений.\n\n" +
                "🛠 Наша команда состоит из высококвалифицированных разработчиков, инженеров и дизайнеров, которые усердно трудятся, чтобы обеспечить высокое качество и передовые технологии в каждом нашем проекте.\n\n" +
                "🛠 Мы специализируемся на разработке программного обеспечения для различных отраслей и секторов, включая бизнес, финансы, здравоохранение, образование и многие другие.\n\n" +
                "🛠 Наша цель - помочь нашим клиентам оптимизировать свои бизнес-процессы, повысить эффективность и улучшить качество своих продуктов и услуг.\n\n" +
                "🛠 Мы гордимся тем, что наш подход к разработке программного обеспечения основан на понимании потребностей и целей наших клиентов.\n\n" +
                "🛠 Пример нашего программного обеспечения: мобильное приложение умный город. Ознакомится вы можете с данным продуктом по ссылке - https://disk.yandex.ru/d/3mSQJLCv23IaWA.";
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
