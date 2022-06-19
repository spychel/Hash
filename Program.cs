
class Program
{
    static void Main(string[] args)
    {
        string login = string.Empty;
        string password = string.Empty;
        
        bool isFilledIn = false;

        do {

            isFilledIn = RegistrationForm(ref login, ref password);

        } while (!isFilledIn);

    
        var isRegisterdInDB = Registration.Register(login, password);
        login = password = "";
        if (isRegisterdInDB == Registration.UserHasBeenRegistered)
        {
            System.Console.WriteLine("Пользователь успешно зарегистрирован\n\nВойдите в систему.\nЛогин:");
            login = System.Console.ReadLine();
            System.Console.WriteLine("Пароль:");
            password = System.Console.ReadLine();
            if(!(string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password)))
            {
                Authorization authorization = new Authorization();
                authorization.Authorize(login, password);
                if(authorization.IsAuthorized())
                {
                    System.Console.WriteLine("Добро пожаловать, {0}", authorization.Login);
                }
                else
                {
                    System.Console.WriteLine("Доступ запрещен!");
                }
            }
            else
            {
                System.Console.WriteLine("Доступ запрещен!");
            }
        }
        else
        {
            System.Console.WriteLine("Логин уже используется!");
        }

        Console.ReadLine();
    }

    static bool RegistrationForm(ref string login, ref string password)
    {
        System.Console.WriteLine("Регистрация.\nВведите логин:");
        login = System.Console.ReadLine();
        System.Console.WriteLine("Введите пароль:");
        password = System.Console.ReadLine();
        if(string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
        {
            System.Console.WriteLine("Не удалось зарегистрироваться!\nДосвидания!");
            return false;
        }
        return true;
    }
}