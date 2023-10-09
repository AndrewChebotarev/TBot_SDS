//------------------------------------------------------------------------------------------------------------------------------------------------
namespace TBot_SDS.Tasks
{
    //------------------------------------------------------------------------------------------------------------------------------------------------
    public class HundleUpdate
    {
        //------------------------------------------------------------------------------------------------------------------------------------------------

        private HundleCheckingMessage hundleCheckingMessage = new();
        private SendMessage sendMessage = new();
        private ConsoleMessage consoleMessage = new();

        private StartCommand startCommand = new();
        private NovelCommand novelCommand = new();
        private DesignServicesCommand designServicesCommand = new();
        private DevelopmentTelegramBOTCommand developmentTelegramBOTCommand = new();
        private GameConstructorCommand gameConstructorCommand = new();
        private GameCreationCommand gameCreationCommand = new();
        private ServiceCalculatorCommand serviceCalculatorCommand = new();
        private SiteDevelopmentCommand SiteDevelopmentCommand = new();
        private SoftwareDevelopmentCommand softwareDevelopmentCommand = new();

        private GoToWebsiteCommand goToWebsite= new();
        private ContactsCommand contacts = new();

        private JsonSerialLocalDbcs jsonSerialLocalDbcs = new();

        private List<long> usersId = new();

        //------------------------------------------------------------------------------------------------------------------------------------------------

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var checkingForMessage = hundleCheckingMessage.CheckingForMessage(update);
            if (!checkingForMessage) return;

            jsonSerialLocalDbcs.JsonSerializ(update.Message.Chat.Id);

            await CommandRoute(botClient, update, cancellationToken);
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------

        private async Task CommandRoute(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            switch (update.Message.Text)
            {
                case "/start":
                    await startCommand.Start(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "Меню":
                    await startCommand.Start(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "/Novel":
                    await novelCommand.Novel(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "Создание новелл":
                    await novelCommand.Novel(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "/GameCreation":
                    await gameCreationCommand.GameCreation(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "Создание игр":
                    await gameCreationCommand.GameCreation(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "/GameConstructor":
                    await gameConstructorCommand.GameConstructor(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "Конструктор игр":
                    await gameConstructorCommand.GameConstructor(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "/SiteDevelopment":
                    await SiteDevelopmentCommand.SiteDevelopment(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "Разработка сайта":
                    await SiteDevelopmentCommand.SiteDevelopment(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "/DevelopmentTelegramBOT":
                    await developmentTelegramBOTCommand.DevelopmentTelegramBOT(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "Разработка Telegram BOT":
                    await developmentTelegramBOTCommand.DevelopmentTelegramBOT(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "/SoftwareDevelopment":
                    await softwareDevelopmentCommand.SoftwareDevelopment(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "Разработка ПО":
                    await softwareDevelopmentCommand.SoftwareDevelopment(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "/DesignServices":
                    await designServicesCommand.DesignServices(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "Услуги дизайна":
                    await designServicesCommand.DesignServices(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "/ServiceCalculator":
                    await serviceCalculatorCommand.ServiceCalculator(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "Калькулятор услуг":
                    await serviceCalculatorCommand.ServiceCalculator(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "Перейти на сайт":
                    await goToWebsite.GoToWebsite(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "/Contacts":
                    await contacts.Contacts(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "Контакты":
                    await contacts.Contacts(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                case "Назад":
                    await startCommand.Start(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;

                default:
                    await startCommand.Start(botClient, update, cancellationToken, sendMessage, consoleMessage);
                    break;
            }
            //------------------------------------------------------------------------------------------------------------------------------------------------
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------------
