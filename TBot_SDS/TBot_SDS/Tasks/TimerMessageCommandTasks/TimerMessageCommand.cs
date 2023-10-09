//------------------------------------------------------------------------------------------------------------------------------------------------
namespace TBot_SDS.Tasks.TimerMessageCommandTasks
{
    //------------------------------------------------------------------------------------------------------------------------------------------------
    public class TimerMessageCommand
    {
        private static TelegramBotClient botClient;
        private static CancellationToken cancellationToken;
        private static SendMessage sendMessage = new();
        private static Timer timer;
        private static int numberMessage = 3;

        public async Task<long> _TimerMessageCommand(TelegramBotClient _botClient, CancellationTokenSource _cts) 
        {
            botClient = _botClient;
            cancellationToken = _cts.Token;

            TimerCallback tm = new TimerCallback(Count);
            timer = new Timer(tm, null, 10, 86400000);

            return 0;
        }

        public static async void Count(object obj)
        {
            List<long> idList = new();

            using (FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jsonDb", "user.json"), FileMode.OpenOrCreate))
            {
                UsersId? usersId = await JsonSerializer.DeserializeAsync<UsersId>(fs);
                idList = usersId.usersIdList;
            }

            if (numberMessage == 3)
            {
                foreach (var id in idList)
                {
                    Console.WriteLine($"Сообщение реклама \"Первая реклама\" отправлена! Id: {id}");
                    await sendMessage.SendingMessageAndPhoto(botClient, cancellationToken, id,
                        "✅ Хотите создать превосходный сайт для своего бизнеса?\n\n" +
                        "✅ Мы здесь, чтобы помочь вам!\n\n" +
                        "✅ Наша команда профессионалов по веб-разработке готова воплотить ваши идеи в элегантный и функциональный веб-сайт, который захватит внимание и привлечет новых клиентов.\n\n" +
                        "✅ Мы внимательно изучим ваши требования и стратегию бизнеса, чтобы создать сайт, который отражает вашу уникальность и позволяет достичь ваших целей.",
                        "ImgSiteDevelopment");
                }
                numberMessage = 1;
            }
            else if (numberMessage == 1) 
            {
                foreach (var id in idList)
                {
                    Console.WriteLine($"Сообщение реклама \"Вторая реклама\" отправлена! Id: {id}");
                    await sendMessage.SendingMessageAndPhoto(botClient, cancellationToken, id,
                        "✅ Хотите восхитить своих клиентов и улучшить свою бизнес-коммуникацию?\n\n" +
                        "✅ Мы предлагаем создание уникальных и интеллектуальных телеграм ботов, которые помогут вам автоматизировать процессы, повысить эффективность и улучшить пользовательский опыт.\n\n" +
                        "✅ Наша команда опытных разработчиков телеграмм ботов готова превратить ваши идеи в удивительные боты, которые могут выполнять разнообразные задачи - от автоматического обслуживания клиентов и рассылки до проведения опросов и предоставления важной информации.",
                        "ImgDevelopmentTelegramBOT");
                }
                numberMessage = 2;
            }
            else
            {
                foreach (var id in idList)
                {
                    Console.WriteLine($"Сообщение реклама \"Третья реклама\" отправлена! Id: {id}");
                    await sendMessage.SendingMessageAndPhoto(botClient, cancellationToken, id,
                        "✅ Готовы обрести новое пространство для вашего бизнеса?\n\n" +
                        "✅ Мы предлагаем услуги по созданию веб-приложений, которые сделают вашу компанию заметной в онлайн-мире.\n\n" +
                        "✅ Наша команда опытных разработчиков использует передовые технологии и передает ваше уникальное видение через красивый и функциональный дизайн.\n\n",
                        "ImgSoftwareDevelopment");
                }
                numberMessage = 3;
            };
        }
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------------
