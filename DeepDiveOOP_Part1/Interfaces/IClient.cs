using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveOOP_Part1
{
    public interface IClient
    {
        public string Name { get; }

        public string Surname { get; }

        public string Patronymic { get; }

        public string PhoneNumber { get; }

        public string Document { get; }

        public void EditName(string newName);

        public void EditSurname(string newSurname);

        public void EditPatronymic(string newPatronymic);

        public void EditPhoneNumber(string newPhoneNumber);

        public void EditDocument(string newEmail);



    }
}
