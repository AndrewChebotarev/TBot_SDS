//Телеграм бот для компании: Sokolov Development Studio
//------------------------------------------------------------------------------------------------------------------------------------------------
namespace TBot_SDS
{
    //------------------------------------------------------------------------------------------------------------------------------------------------
    class Program
    {
        //------------------------------------------------------------------------------------------------------------------------------------------------

        private static TelegramBotClient botClient = new TelegramBotClient("6480764306:AAHIjYepQdYxQB2pWN3vfWSI8zzn25cqdIU");
        private static CancellationTokenSource cts = new CancellationTokenSource();

        //------------------------------------------------------------------------------------------------------------------------------------------------

        public async static Task Main(string[] args)
        {
            HundleUpdate hundleUpdate = new();
            HandlePollingError hundlePollingError = new();

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            Update update = new();

            botClient.StartReceiving(
                updateHandler: hundleUpdate.HandleUpdateAsync,
                pollingErrorHandler: hundlePollingError.HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );

            TimerMessageCommand timerCommand = new TimerMessageCommand();
            await timerCommand._TimerMessageCommand(botClient, cts);

            await ConsoleHelper();
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------

        private async static Task ConsoleHelper()
        {
            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            cts.Cancel();
        }
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------
}