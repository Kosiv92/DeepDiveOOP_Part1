using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveOOP_Part1
{
    public class ConsoleInterfaceMethods : IUserInterface
    {
        private ClientManager _clientManager;


        public ClientManager ClientManager
        {
            get => _clientManager;
            set => _clientManager = value;
        }

        const string currentValueStr = "Текущее значение: ";
        const string inputValueStr = "Введите новое значение: ";
        const string repeatValueNSP = "Некорректный ввод. Необходимо ввести не мение двух и не более 20 символов. Повторите попытку: ";
        const string repeatValuePhone = "Некорректный ввод. Необходимо ввести 11 цифр. Номера телефона начинаются с цифры 8. Повторите попытку: ";
        const string repeatValueDocument = "Некорректный ввод. Необходимо ввести 10 символов. Повторите попытку: ";
        const string accessDenied = "Отсутствует доступ для редактирования данного поля!";
        const string repeatNumberOfClient = "Некорректный ввод. Введите порядковый номер клиента для редактирования.";

        public ConsoleInterfaceMethods(ClientManager clientManager)
        {
            _clientManager = clientManager;
        }

        public void ShomMainMenu(ApplicationUser user)
        {
            while (true)
            {

                //массив пунктов главного меню
                string[] menu = { "Показать список всех клиентов", "Добавить нового клиента", "Редактировать данные клиента", "Сохранить данные", "Выход" };

                int choiceByUser = Menu.ChooseMenuItem(menu);

                switch (choiceByUser)
                {

                    case 0:
                        ShowClientList(ClientManager.Clients);  //показать всех клиентов
                        Console.Write("Нажмите любую клавишу...");

                        Console.ReadKey();
                        break;

                    case 1:
                        _clientManager.AddClient(AddNewClient()); //добавление нового клиента
                        break;

                    case 2:
                        IClient client = ChooseClient(ClientManager.Clients);
                        ClientData field = ChooseField(); //выбор поля клиента для редактирования
                        EditField(client, field);
                        break;

                    case 3:
                        _clientManager.SaveSlients();
                        break;

                    case 4:                        
                        Environment.Exit(0);
                        break;
                }
            }
        }

        /// <summary>
        /// Метод получения от пользователя данных о новом клиенте
        /// </summary>
        /// <returns>Новый клиент</returns>
        public IClient AddNewClient()
        {
            Console.WriteLine("Введите имя клиента: ");
            string name = GetFieldValue_NSP();

            Console.WriteLine("Введите фамилию клиента: ");
            string surname = GetFieldValue_NSP();

            Console.WriteLine("Введите отчество клиента: ");
            string patronymic = GetFieldValue_NSP();

            Console.WriteLine("Введите номер телефона клиента: ");
            string phoneNumber = GetFieldValue_Phone();

            Console.WriteLine("Введите серию и номер паспорта клиента: ");
            string document = GetFieldValue_Document();

            IClient client = new Client(name, surname, patronymic, phoneNumber, document);

            return client;                        
        }

        public void ShowClientList(List<IClient> list)
        {
            Console.Clear();

            string[] titles = { "№ п/п", "Имя", "Фамилия", "Отчество", "Номер телефона", "Паспорт" };  //объявляем массив с наименованием столбцов

            Console.WriteLine($"{titles[0],5} {titles[1],21} {titles[2],21} {titles[3],21} {titles[4],12} {titles[5],12}");

            int ClientNumber = 1;

            foreach (var client in list)
            {
                Console.Write($"{ClientNumber,-5} ");   //вывод порядкового номера клиента

                if (ClientManager.ActiveApplicationUser.UserAccesRightments.NameAccess.IsVisible) Console.Write($"{client.Name,-21} "); //вывод имени клиента
                else Console.Write(new String('*', client.Name.Length));

                if (ClientManager.ActiveApplicationUser.UserAccesRightments.SurnameAccess.IsVisible) Console.Write($"{client.Surname,-21} "); //вывод фамилии клиента
                else Console.Write(new String('*', client.Surname.Length));

                if (ClientManager.ActiveApplicationUser.UserAccesRightments.PatronymicAccess.IsVisible) Console.Write($"{client.Patronymic,-21} "); //вывод отчества клиента
                else Console.Write(new String('*', client.Patronymic.Length));

                if (ClientManager.ActiveApplicationUser.UserAccesRightments.PhoneNumberAccess.IsVisible) Console.Write($"{client.PhoneNumber,-12} "); //вывод номера телефона клиента
                else Console.Write(new String('*', 11));

                if (ClientManager.ActiveApplicationUser.UserAccesRightments.DocumentAccess.IsVisible) Console.Write($"{client.Document.Substring(0, -12) + " " + client.Document.Substring(4, 6),-12} "); //вывод номера паспорта клиента
                else Console.Write(new String('*', 4) + " " + new String('*', 6));

                Console.WriteLine();
            }

            Console.WriteLine();

        }

        public ClientData ChooseField()
        {
            string[] menu = { "Изменить имя клиента",
                              "Изменить фамилию клиента",
                              "Изменить отчество клиента",
                              "Изменить номер телефона клиента",
                              "Изменить данные паспорта клиента",
                              "Отмена" };
            int choiceByUser = Menu.ChooseMenuItem(menu);
            switch (choiceByUser)
            {
                case 0: return ClientData.Name;
                case 1: return ClientData.Surname;
                case 2: return ClientData.Patronymic;
                case 3: return ClientData.PhoneNumber;
                case 4: return ClientData.Document;
                case 5:
                default: return ClientData.None;
            }
        }

        public IClient ChooseClient(List<IClient> list)
        {
            ShowClientList(list);
            Console.WriteLine("Введите порядковый номер клиента для редактирования.");
            bool IsNumOfClient = false;
            int number = 0;
            while (!IsNumOfClient)
            {
                bool IsNumber = Int32.TryParse(Console.ReadLine(), out number);
                IsNumOfClient = (IsNumber && number <= list.Count && number > 0);
                if (!IsNumOfClient) Console.WriteLine();
            }
            return list[number - 1];
        }

        /// <summary>
        /// Редактирование данных клиента
        /// </summary>
        /// <param name="client">Клиент данные которого редактируются</param>
        /// <param name="fieldName">Поле данных подвергаемое редактированию</param>
        public void EditField(IClient client, ClientData fieldName)
        {
            switch (fieldName)
            {
                case ClientData.Name:
                    if (ClientManager.ActiveApplicationUser.UserAccesRightments.NameAccess.IsEditable) //проверка поля на возможность редактирования
                    {
                        Console.WriteLine($"{0} {1}", currentValueStr, client.Name);
                        Console.WriteLine(inputValueStr);
                        client.EditName(GetFieldValue_NSP());
                    }
                    else
                    {
                        Console.WriteLine(accessDenied);
                        Console.ReadKey();
                    }
                    break;
                case ClientData.Surname:
                    if (ClientManager.ActiveApplicationUser.UserAccesRightments.SurnameAccess.IsEditable) //проверка поля на возможность редактирования
                    {
                        Console.WriteLine($"{0} {1}", currentValueStr, client.Surname);
                        Console.WriteLine(inputValueStr);
                        client.EditSurname(GetFieldValue_NSP());
                    }
                    else
                    {
                        Console.WriteLine(accessDenied);
                        Console.ReadKey();
                    }
                    break;
                case ClientData.Patronymic:
                    if (ClientManager.ActiveApplicationUser.UserAccesRightments.PatronymicAccess.IsEditable) //проверка поля на возможность редактирования
                    {
                        Console.WriteLine($"{0} {1}", currentValueStr, client.Patronymic);
                        Console.WriteLine(inputValueStr);
                        client.EditPatronymic(GetFieldValue_NSP());
                    }
                    else
                    {
                        Console.WriteLine(accessDenied);
                        Console.ReadKey();
                    }
                    break;
                case ClientData.PhoneNumber:
                    if (ClientManager.ActiveApplicationUser.UserAccesRightments.PhoneNumberAccess.IsEditable) //проверка поля на возможность редактирования
                    {
                        Console.WriteLine($"{0} {1}", currentValueStr, client.PhoneNumber);
                        Console.WriteLine(inputValueStr);
                        client.EditPhoneNumber(GetFieldValue_Phone());
                    }
                    else
                    {
                        Console.WriteLine(accessDenied);
                        Console.ReadKey();
                    }
                    break;
                case ClientData.Document:
                    if (ClientManager.ActiveApplicationUser.UserAccesRightments.DocumentAccess.IsEditable) //проверка поля на возможность редактирования
                    {
                        Console.WriteLine($"{0} {1}", currentValueStr, client.Document);
                        Console.WriteLine(inputValueStr);
                        client.EditDocument(GetFieldValue_NSP());
                    }
                    else
                    {
                        Console.WriteLine(accessDenied);
                        Console.ReadKey();
                    }
                    break;
            }
        }

        /// <summary>
        /// Метод получения от пользователя данных об имени/фамилии/отчестве
        /// </summary>
        /// <returns>Данные введенные пользователем</returns>
        private string GetFieldValue_NSP()
        {            
            bool correctValue = false;
            string newValue = null;
            while (!correctValue)
            {
                newValue = Console.ReadLine();
                correctValue = (!String.IsNullOrEmpty(newValue) && newValue.Length < 20 && newValue.Length > 1);
                if (!correctValue) Console.WriteLine(repeatValueNSP);
            }
            return newValue;
        }

        /// <summary>
        /// Метод получения от пользователя данных об номере телефона
        /// </summary>
        /// <returns></returns>
        private string GetFieldValue_Phone()
        {
            bool correctValue = false;
            string newValue = null;
            while (!correctValue)
            {
                newValue = Console.ReadLine();
                bool isNumber = long.TryParse(newValue, out long number);
                correctValue = (!String.IsNullOrEmpty(newValue) && newValue.Length == 11 && isNumber);
                if (!correctValue) Console.WriteLine(repeatValuePhone);
            }
            return newValue;
        }

        /// <summary>
        /// Метод получения от пользователя данных о номере паспорта
        /// </summary>
        /// <returns></returns>
        private string GetFieldValue_Document()
        {
            bool correctValue = false;
            string newValue = null;
            while (!correctValue)
            {
                newValue = Console.ReadLine();
                bool isNumber = long.TryParse(newValue, out long number);
                correctValue = (!String.IsNullOrEmpty(newValue) && newValue.Length == 10 && isNumber);
                if (!correctValue) Console.WriteLine(repeatValueDocument);
            }
            return newValue;
        }

        IRepository IUserInterface.SetRepository()
        {
            Console.WriteLine("Перед началом работы укажите директорию где находится или где необходимо создать файл со списком клиентов\n" +
                "Файл должен называться - \"clients.csv\\nВам необходимо вписать путь до директории с файлом в формате - \"D:\\MyFiles\"" +
                "В случае если файл отсутствует по указанному пути он будет создан\n");
            string pathToFile = Console.ReadLine();
            IRepository repository = new FileRepository_CSV(SetPath(pathToFile));
            return repository;
        }

        /// <summary>
        /// Метод установки пути к файлу со списком клиентов
        /// </summary>
        /// <param name="pathToFile"></param>
        /// <returns></returns>
        public string SetPath(string pathToFile)
        {
            string path;
            while (true)
            {
                try
                {
                    DirectoryInfo infoAboutDirectoryOfDiary = new DirectoryInfo(pathToFile);   //проверка на пустую строку
                    path = pathToFile + @"\clients.csv";
                    if (File.Exists(path))
                    {
                        Console.WriteLine(
                            $"Обнаружен существующий файл со списком клиентов - {path}");
                        //diary.NoteRepository.LoadNotes();
                        Console.ReadKey();
                        break;
                    }
                    else
                    {
                        using (File.Create(path))
                            Console.WriteLine($"Файл не обнаружен. Будет создан новый файл для хранения списка клиентов - {path}");
                        Console.ReadKey();
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка установки пути. Проверьте правильности формата (пример - \"D:\\MyFiles\") и попробуйте снова");
                    Console.WriteLine($"Ошибка:\n{ex}");
                }

                Console.WriteLine();
                Console.Write("Введите путь к файлу снова: ");
                pathToFile = Console.ReadLine();

            }
            return path;
        }

        
    }
}
