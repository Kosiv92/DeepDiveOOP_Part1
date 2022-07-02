using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveOOP_Part1
{
    public class FileRepository_CSV : IRepository
    {
        private readonly string _pathToRepository;        

        public string PathToRepository { get => _pathToRepository; }

        public FileRepository_CSV(string path)
        {
            _pathToRepository = path;
        }

        public List<IClient> Load()
        {
            string[] lines = File.ReadAllLines(_pathToRepository);   //объявление массива всех строк файла                         

            List<IClient> clients = new List<IClient>();

            if (lines.Length != 0)
            {
                using (StreamReader fileReader = new StreamReader(_pathToRepository))
                {
                    while (!fileReader.EndOfStream)
                    {
                        string rowFromFile = fileReader.ReadLine();   //объявление переменной для хранения данных строки из файла 

                        clients.Add(Parse(rowFromFile));   //добавление нового объекта в список клиентов                                                
                    }
                }
            }
            
            return clients;
        }
        
        /// <summary>
        /// Метод преобразования строки в экземпляр IClient
        /// </summary>
        /// <param name="rowFromFile"></param>
        /// <returns></returns>
        private static IClient Parse(string rowFromFile)
        {
            string[] fieldsOfClass = rowFromFile.Split(';');  //объявлением массива c полями объекта заметка                        

            IClient newClient = new Client(fieldsOfClass[0], fieldsOfClass[1], fieldsOfClass[2], fieldsOfClass[3], fieldsOfClass[4]);

            return newClient;
        }

        public void Save(List<IClient> clients)
        {
            using (StreamWriter writeToFile = new StreamWriter(_pathToRepository, false, Encoding.UTF8))
            {
                foreach (IClient client in clients) writeToFile.WriteLine(ClientToString(client));
            }
        }

        private string ClientToString(IClient client)
        {
            return client.Name + ";" + client.Surname + ";" + client.Patronymic + ";" + client.PhoneNumber + ";" + client.Document;
        }                
        
    }
}
