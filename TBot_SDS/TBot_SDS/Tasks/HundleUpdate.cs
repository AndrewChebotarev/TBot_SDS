using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBot_SDS.Tasks.HelpTasks;

namespace TBot_SDS.Tasks
{
    public class HundleUpdate
    {
        private HundleCheckingMessage hundleCheckingMessage = new();
        private SendMessage sendMessage = new();
        private ConsoleMessage consoleMessage = new();
        private List<long> UserList = new();
        private long Admin = 814800925;
        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var checkingForMessage = hundleCheckingMessage.CheckingForMessage(update);
            if (!checkingForMessage) return;

            ExamUserForList(update);

            StartCommand(botClient, update, cancellationToken);
        }

        private void ExamUserForList(Update update)
        {
            if (!UserList.Contains(update.Message.Chat.Id) && update.Message.Chat.Id != Admin)
                UserList.Add(update.Message.Chat.Id);
        }

        private async Task StartCommand(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message.Text == "/start")
            {
                foreach (var user in UserList)
                {
                    NewText(update);
                    consoleMessage.SendingConsole(update.Message.Text, update.Message.Chat.Id);

                    await sendMessage.SendingMessage(botClient, cancellationToken, update.Message.Chat.Id, "Вы подписаны на наш телеграм бот вот вам ссыль https://vk.com/sokolov_development_studio ");
                }
            }
        }

        private async Task PushTextForUsers(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Message.Text == "1 сообщение" && update.Message.Chat.Id == Admin)
            {
                foreach (var user in UserList)
                {
                    NewText(update);
                    consoleMessage.SendingConsole(update.Message.Text, update.Message.Chat.Id);
                    await sendMessage.SendingMessageAndPhoto(botClient, cancellationToken, user, "Первое предложение для перехода - https://vk.com/sokolov_development_studio ");
                }
            }

            if (update.Message.Text == "2 сообщение" && update.Message.Chat.Id == Admin)
            {
                foreach (var user in UserList)
                {
                    NewText(update);
                    consoleMessage.SendingConsole(update.Message.Text, update.Message.Chat.Id);
                    await sendMessage.SendingMessageAndPhoto(botClient, cancellationToken, user, "Второе предложение для перехода - https://vk.com/sokolov_development_studio ");
                }
            }

            if (update.Message.Text == "3 сообщение" && update.Message.Chat.Id == Admin)
            {
                foreach (var user in UserList)
                {
                    NewText(update);
                    consoleMessage.SendingConsole(update.Message.Text, update.Message.Chat.Id);
                    await sendMessage.SendingMessageAndPhoto(botClient, cancellationToken, user, "Третье предложение для перехода - https://vk.com/sokolov_development_studio ");
                }
            }
        }

        private void NewText(Update update) => update.Message.Text = update.Message.Text;
    }
}
