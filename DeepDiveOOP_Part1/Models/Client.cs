using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveOOP_Part1
{
    public class Client : IClient
    {
        private string _name;

        private string _surname;

        private string _patronymic;

        private string _phoneNumber;

        private string _document;

        //const string accessDenied = "У пользователя отсутствуют права для редактирования данного поля";

        public Client(string name, string surname, string patronymic, string phoneNumber, string document)
        {
            _name = name;
            _surname = surname;
            _patronymic = patronymic;
            _phoneNumber = phoneNumber;
            _document = document;
        }

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public string Surname
        {
            get => _surname;
            private set => _surname = value;
        }

        public string Patronymic
        {
            get => _patronymic;
            private set => _patronymic = value;
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            private set => _phoneNumber = value;
        }

        public string Document
        {
            get => _document;
            private set => _document = value;
        }

        public void EditName(string newName) => Name = newName;        

        public void EditSurname(string newSurname) => Surname = newSurname;
        
        public void EditPatronymic(string newPatronymic) => Patronymic = newPatronymic;
        
        public void EditPhoneNumber(string newPhoneNumber) => PhoneNumber = newPhoneNumber;
        
        public void EditDocument(string newEmail) => Document = newEmail;
        
    }
}
