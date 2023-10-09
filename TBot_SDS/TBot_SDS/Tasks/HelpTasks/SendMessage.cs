//------------------------------------------------------------------------------------------------------------------------------------------------
namespace TBot_SDS.Tasks.HelpTasks
{
    //------------------------------------------------------------------------------------------------------------------------------------------------
    public class SendMessage
    {
        //------------------------------------------------------------------------------------------------------------------------------------------------
        public async Task SendingMessage(ITelegramBotClient botClient, CancellationToken cancellationToken, long id, string text)
        {
            Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: id,
                text: text,
                cancellationToken: cancellationToken);
        }

        public async Task SendingMessageAndPhoto(ITelegramBotClient botClient, CancellationToken cancellationToken, long id, string text, string ImgName)
        {
            var PhotoPath = GetImgPath(ImgName);

            using (var fileStream = new FileStream(PhotoPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Message message = await botClient.SendPhotoAsync(
                    chatId: id,
                    photo: new InputFileStream(fileStream),
                    caption: text,
                    cancellationToken: cancellationToken);
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
        private string GetImgPath(string PicName)
        {
            if (PicName == "ImgMenu") return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "ImgMenu.png");
            else if (PicName == "ImgNovel") return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "ImgNovel.jpg");
            else if (PicName == "ImgGameCreation") return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "ImgGameCreation.jpg");
            else if (PicName == "ImgGameConstructor") return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "ImgGameConstructor.jpg");
            else if (PicName == "ImgSiteDevelopment") return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "ImgSiteDevelopment.jpg");
            else if (PicName == "ImgDevelopmentTelegramBOT") return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "ImgDevelopmentTelegramBOT.jpg");
            else if (PicName == "ImgSoftwareDevelopment") return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "ImgSoftwareDevelopment.jpg");
            else if (PicName == "ImgDesignServices") return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "ImgDesignServices.jpg");
            else if (PicName == "ImgServiceCalculator") return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "ImgServiceCalculator.jpg");
            else if (PicName == "ImgWebSite") return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "ImgWebSite.jpg");
            else if (PicName == "ImgContacts") return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "ImgContacts.jpg");
            else return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ImgMenu.jpg"); ;
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------------
