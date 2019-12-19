using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Models
{
    class User
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Birthday { get; set; }
        public string documentNumber { get; set; }
        public string Email { get; set; }
        public string NumberOrder { get; set; }

        public User(string surname, string name, string patronymic, string birthday,
           string document, string email,string numberOrder )
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Birthday = birthday;
            documentNumber = document;
            Email = email;
            NumberOrder = numberOrder;
        }
    }
}
