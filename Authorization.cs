class Authorization
{
    bool _isAuthorized = false;
    User? dbUser;

    public string Login { get { return dbUser.Login;} }
    public bool IsAuthorized()
    {
        return _isAuthorized;
    }
    public bool Authorize(string login, string password)
    {
        int userId = DataBase.GetUserIdByLogin(login);
        if(!(userId == DataBase.UserHasNotFound))
        {
            dbUser = DataBase.GetUserById(userId);
            var salt = Hash.GetSalt(dbUser.PasswordHash);
            var dbUserHash = Hash.GetHash(dbUser.PasswordHash);

            var userHash = Hash.MakeHash(salt, password);

            for(int i = 0; i < dbUserHash.Length; i++)
            {
                if(dbUserHash[i] != userHash[i])
                    return false;
            }
            _isAuthorized = true;
            return _isAuthorized;
        }
        else
        {
            return _isAuthorized;
        }
    }


}