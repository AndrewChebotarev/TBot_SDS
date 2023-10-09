//Класс для записи Id новых пользователей в json
//------------------------------------------------------------------------------------------------------------------------------------------------
namespace TBot_SDS.local_Db
{

    //------------------------------------------------------------------------------------------------------------------------------------------------
    public class JsonSerialLocalDbcs
    {
        //------------------------------------------------------------------------------------------------------------------------------------------------

        private List<long> usersIdList = new();

        //------------------------------------------------------------------------------------------------------------------------------------------------
        public async void JsonSerializ(long Id)
        {
            try
            {
                await ReadIdFromJson();
                var isNewUser = ExamForNewUser(Id);

                if (!isNewUser) return;
                else AddNewUserFromDb(Id);
            }
            catch { AddNewUserFromDb(Id); }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------

        private async Task<List<long>> ReadIdFromJson()
        {
            using (FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jsonDb", "user.json"), FileMode.OpenOrCreate))
            {
                UsersId? usersId = await JsonSerializer.DeserializeAsync<UsersId>(fs);
                this.usersIdList = usersId.usersIdList;
            }
            return this.usersIdList;
        }

        private bool ExamForNewUser(long Id)
        {
            if (usersIdList != null)
            {
                foreach (var userId in usersIdList) if (Id == userId) return false;
            }
            return true;
        }

        private async void AddNewUserFromDb(long Id)
        {
            using (FileStream fs = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "jsonDb", "user.json"), FileMode.OpenOrCreate))
            {
                usersIdList.Add(Id);
                UsersId userId = new(usersIdList);
                await JsonSerializer.SerializeAsync<UsersId>(fs, userId);
                Console.WriteLine("Data has been saved to file!");
            }
        }
        //------------------------------------------------------------------------------------------------------------------------------------------------
    }
    //------------------------------------------------------------------------------------------------------------------------------------------------
}
//------------------------------------------------------------------------------------------------------------------------------------------------
