static class Registration
{
    public const bool LoginIsUsed = false;
    public const bool UserHasBeenRegistered = true;
    public static bool Register(string login, string password)
    {
        if(DataBase.GetUserIdByLogin(login) == DataBase.UserHasNotFound)
        {
            DataBase.AddUser(login, Hash.CreatePasswordHash(password));
            return UserHasBeenRegistered;
        }
        else
        {
            return LoginIsUsed;
        }
    }
}