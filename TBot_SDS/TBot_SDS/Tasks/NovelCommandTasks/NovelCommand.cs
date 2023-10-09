//------------------------------------------------------------------------------------------------------------------------------------------------
namespace TBot_SDS.Tasks.NovelCommandTasks
{
    //------------------------------------------------------------------------------------------------------------------------------------------------
    public class NovelCommand
    {
        public async Task Novel(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken, SendMessage sendMessage, ConsoleMessage consoleMessage)
        {
            consoleMessage.SendingConsole(update.Message.Text, update.Message.Chat.Id);
            await sendMessage.SendingMessageAndPhoto(botClient, cancellationToken, update.Message.Chat.Id, GetText(), "ImgNovel");

            var keyboardButtons = GetKeyboardButtons();
            var replyMarkup = new ReplyKeyboardMarkup(keyboardButtons) { ResizeKeyboard = true };
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, "🔜", replyMarkup: replyMarkup);
        }

        private string GetText()
        {
            return "💟 Визуальная новелла – это интерактивный жанр видеоигр, который сочетает в себе элементы повествования, искусства и игровой механики.\n\n" +
                "💟 В нашей игре игроку предоставляется возможность влиять на сюжет, принимать решения относительно персонажей и их поступков, что, в свою очередь, влияет на исход истории.\n\n" +
                "💟 Такой подход позволяет игрокам более погрузиться в мир игры и создать свой уникальный сценарий завершения.\n\n" +
                "💟 Так что, если вы любите повествовательный жанр и хотите углубиться в захватывающую историю с классным дизайном, то стоит попробовать!\n\n" +
                "💟 О данной игре выходила новость - https://chr.plus.rbc.ru/partners/627274437a8aa9a09fdf3923.\n\n" +
                "💟 Игру вы можете скачать нажав тут - https://disk.yandex.ru/d/40fg9Y39_8n-fw. После скачивания, разархивируйте, запустите файл под названием \"Прощальное письмо\". Можете наслаждаться игрой! Мы ждем от вас отзывы, для связи нажмите кнопку \"Контакты\".";
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
