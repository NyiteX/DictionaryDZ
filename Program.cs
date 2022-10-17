Manager M = new();
char vvod;
do
{
    Console.Clear();
    Console.WriteLine("1.Добавление\n2.Удаление\n3.Изменение\n4.Вывод пароля по логину\n5.Вывод на экран всей базы");
    Console.WriteLine("Esc - Выход\n");
    vvod = Console.ReadKey().KeyChar;
    switch(vvod)
    {
        case '1':
            Console.Clear();
            M.Add();
            Console.WriteLine("Press any key to continue.\n");
            Console.ReadKey();
            break;
        case '2':
            Console.Clear();
            M.Delete();
            Console.WriteLine("Press any key to continue.\n");
            Console.ReadKey();
            break;
        case '3':
            {
                if (M.GetCount() > 0)
                {
                    char vvod2;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("1.Изменить логин\n2.Изменить пароль");
                        Console.WriteLine("Esc - Выход\n");
                        vvod2 = Console.ReadKey().KeyChar;
                        switch (vvod2)
                        {
                            case '1':
                                Console.Clear();
                                M.EditName(M.Search());
                                Console.WriteLine("Press any key to continue.\n");
                                Console.ReadKey();
                                break;
                            case '2':
                                Console.Clear();
                                M.EditPass(M.Search());
                                Console.WriteLine("Press any key to continue.\n");
                                Console.ReadKey();
                                break;
                        }
                    } while (vvod2 != 27);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Список пуст.");
                    Console.WriteLine("Press any key to continue.\n");
                    Console.ReadKey();
                }
            }
            break;
        case '4':
            if (M.GetCount() > 0)
            {
                Console.Clear();
                Console.WriteLine("Пароль: " + M.ShowPass()); 
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Список пуст.");
            }
            Console.WriteLine("Press any key to continue.\n");
            Console.ReadKey();
            break;
        case '5':
            Console.Clear();
            M.Print();
            Console.WriteLine("Press any key to continue.\n");
            Console.ReadKey();
            break;
    }
} while (vvod != 27);

class Manager
{
    Dictionary<string, string> PassBase = new Dictionary<string, string>();

    public int GetCount() { return PassBase.Count; }
    public void Add()
    {   
        Console.Write("Введите логин: ");
        string? name = Console.ReadLine();
        Console.Write("Введите пароль: ");
        string? pass = Console.ReadLine();
        PassBase.Add(name, pass);
        Console.WriteLine("Добавлено.");
    }
    public void Delete()
    {
        if (PassBase.Count > 0)
        {
            Console.Write("Введите логин: ");
            string? name = Console.ReadLine();
            PassBase.Remove(name);
        }
        else
            Console.WriteLine("Список пуст.");
    }
    public void Print()
    {
        if (PassBase.Count > 0)
            foreach (var pass in PassBase)
                Console.WriteLine(pass);
        else
            Console.WriteLine("Список пуст.");
    }
    public string ShowPass()
    {
        Console.Write("Введите логин: ");
        string? name = Console.ReadLine();
        if (PassBase.TryGetValue(name, out string? pass)) return pass;
        else return "Не найдено";
    }
    public string Search()
    {
        Console.Write("Введите логин: ");
        string? name = Console.ReadLine();
        
        if (PassBase.ContainsKey(name)) return name;
        else return "";
    }
    public void EditPass(string? login)
    {
        if (login.Length > 0)
        {
            Console.WriteLine("Новый пароль: ");
            PassBase[login] = Console.ReadLine();
        }
        else
            Console.WriteLine("Не найдено");
    }
    public void EditName(string? login)
    {
        if (login.Length > 0)
        {
            PassBase.TryGetValue(login, out string? pass);
            PassBase.Remove(login);
            Console.WriteLine("Новый логин: ");
            login = Console.ReadLine();
            PassBase.Add(login, pass);
        }            
        else
            Console.WriteLine("Не найдено");
    }
}
