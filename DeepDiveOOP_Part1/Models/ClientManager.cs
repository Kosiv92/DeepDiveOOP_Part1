using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveOOP_Part1
{
    public class ClientManager
    {
        ApplicationUser _activeApplicationUser;
        
        IRepository _repository;
                
        /// <summary>
        /// Активный пользователь приложения
        /// </summary>
        public ApplicationUser ActiveApplicationUser { get => _activeApplicationUser; set => _activeApplicationUser = value; }

        public IRepository Repository { get => _repository; set => _repository = value; }

        private List<IClient> _clients;

        public List<IClient> Clients { get => _clients; }

        public ClientManager(ApplicationUser applicationUser)
        {
            _activeApplicationUser = applicationUser;
            _clients = new List<IClient>();
        }
        
        /// <summary>
        /// Метод редактирования данных клиента
        /// </summary>
        /// <param name="client">новые данные клиента</param>
        /// <param name="index">индекс клиента</param>
        public void EditClient(IClient client, int index)
        {
            _clients[index] = client;
        }

        public void LoadClients()
        {
            _clients = _repository.Load();
        }

        public void SaveSlients()
        {
            _repository.Save(_clients);
        }

        /// <summary>
        /// Добавление нового клиента в список клиентов
        /// </summary>
        /// <param name="client">Новый клиент</param>
        public void AddClient(IClient client)
        {            
            _clients.Add(client);
        }

    }
}
