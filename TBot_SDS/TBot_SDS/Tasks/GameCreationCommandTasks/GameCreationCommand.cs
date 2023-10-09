//------------------------------------------------------------------------------------------------------------------------------------------------
namespace TBot_SDS.Tasks.GameCreationCommandTasks
{
    //------------------------------------------------------------------------------------------------------------------------------------------------
    public class GameCreationCommand
    {
        public async Task GameCreation(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, SendMessage sendMessage, ConsoleMessage consoleMessage)
        {
            consoleMessage.SendingConsole(update.Message.Text, update.Message.Chat.Id);
            await sendMessage.SendingMessageAndPhoto(botClient, cancellationToken, update.Message.Chat.Id, GetText(), "ImgGameCreation");

            var keyboardButtons = GetKeyboardButtons();
            var replyMarkup = new ReplyKeyboardMarkup(keyboardButtons) { ResizeKeyboard = true };
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, "🔜", replyMarkup: replyMarkup);
        }
        private string GetText()
        {
            return "🚀 Мы - инновационная компания, специализирующаяся на разработке увлекательных и захватывающих игр.\n\n" +
                "🚀 Наша команда состоит из опытных разработчиков, дизайнеров и художников, увлеченных игровой индустрией и стремящихся создавать высококачественные игровые продукты.\n\n" +
                "🚀 Мы гордимся нашим твердым преданностью качеству и инновациям.\n\n" +
                "🚀 Мы уделяем большое внимание деталям и стремимся сделать каждую нашу игру неповторимой.\n\n" +
                "🚀 Наша цель - предоставить нашим игрокам незабываемые и захватывающие впечатления через уникальные сюжеты, эмоциональные персонажи и захватывающие игровые миры.\n\n" +
                "🚀 Мы ждем вас, для связи нажмите кнопку \"Контакты\".";
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
