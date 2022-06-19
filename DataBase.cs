static class DataBase
{

    public const int UserHasNotFound = 0;
    static List<User> users = new List<User>();

    public static void AddUser(string login, string passwordHash)
    {
        users.Add(new User {
            Id = GetLastAddedUserId() + 1,
            Login = login,
            PasswordHash = passwordHash
        });
    }

    static int GetLastAddedUserId()
    {
        if (!users.Any()) {
            return 0;
        }

        return users.Max(x => x.Id);
    }

    public static int GetUserIdByLogin(string login)
    {
        User? user = users.FirstOrDefault(x => x.Login == login);
        if(user != null)
            return user.Id;
        return UserHasNotFound;
    }

    public static User GetUserById(int id)
    {
        return users.First(x => x.Id == id);
    }
}