using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepDiveOOP_Part1
{
    public class AccessRightments
    {
        public readonly FieldAccessRightments NameAccess;

        public readonly FieldAccessRightments SurnameAccess;

        public readonly FieldAccessRightments PatronymicAccess;

        public readonly FieldAccessRightments PhoneNumberAccess;

        public readonly FieldAccessRightments DocumentAccess;

        public AccessRightments(FieldAccessRightments name, FieldAccessRightments surname, FieldAccessRightments patronymic, FieldAccessRightments phone, FieldAccessRightments document)
        {
            NameAccess = name;
            SurnameAccess = surname;
            PatronymicAccess = patronymic;
            PhoneNumberAccess = phone;
            DocumentAccess = document;
        }

        /// <summary>
        /// Метод возвращает набор прав для пользователя "Консультант"
        /// </summary>
        /// <returns></returns>
        public static AccessRightments GetConsultantAccessRightments()
        {
            var name = new FieldAccessRightments(true, false);

            var surname = new FieldAccessRightments(true, false);

            var patronimyc = new FieldAccessRightments(true, false);

            var phone = new FieldAccessRightments(true, true);

            var document = new FieldAccessRightments(false, false);

            var consAccessRight = new AccessRightments(name, surname, patronimyc, phone, document);

            return consAccessRight;
        }
    }
}
