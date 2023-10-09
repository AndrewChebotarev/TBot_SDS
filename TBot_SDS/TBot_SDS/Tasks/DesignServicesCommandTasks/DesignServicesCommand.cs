//------------------------------------------------------------------------------------------------------------------------------------------------
namespace TBot_SDS.Tasks.DesignServicesCommandTasks
{
    //------------------------------------------------------------------------------------------------------------------------------------------------
    public class DesignServicesCommand
    {
        public async Task DesignServices(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, SendMessage sendMessage, ConsoleMessage consoleMessage)
        {
            consoleMessage.SendingConsole(update.Message.Text, update.Message.Chat.Id);
            await sendMessage.SendingMessageAndPhoto(botClient, cancellationToken, update.Message.Chat.Id, GetText(), "ImgDesignServices");

            var keyboardButtons = GetKeyboardButtons();
            var replyMarkup = new ReplyKeyboardMarkup(keyboardButtons) { ResizeKeyboard = true };
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, "🔜", replyMarkup: replyMarkup);
        }
        private string GetText()
        {
            return "🎆 Мы компания, предоставляющая широкий спектр услуг дизайна, нацеленных на создание эстетически привлекательных и функциональных визуальных решений для наших клиентов.\n\n" +
                "🎆 Наша команда состоит из талантливых дизайнеров, которые обладают креативностью и глубоким пониманием дизайнерских принципов.\n\n" +
                "🎆 Мы предлагаем услуги в следующих областях дизайна: Веб-дизайн: Мы разрабатываем уникальные и привлекательные дизайны для веб-сайтов, которые сочетают в себе пользовательскую дружелюбность, простоту навигации и визуальную привлекательность.\n\n" +
                "🎆 Мы учитываем ваши брендинговые цели и создаем дизайн, который отражает уникальность вашего бизнеса.\n\n" +
                "🎆 Графический дизайн: Мы создаем логотипы, фирменный стиль, брендбуки, рекламные материалы и другие графические элементы, которые помогут вашему бренду выделиться и вызывать доверие у ваших клиентов.";
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
