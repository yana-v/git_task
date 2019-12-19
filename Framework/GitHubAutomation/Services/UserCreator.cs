using GitHubAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubAutomation.Services
{
    class UserCreator
    {
        public static User WithAllProperties()
        {
            return new User(TestDataReader.GetUserData("Surname"), TestDataReader.GetUserData("Name"), TestDataReader.GetUserData("Patronymic"),
                TestDataReader.GetUserData("Birthday"), TestDataReader.GetUserData("Document"), TestDataReader.GetUserData("Email"), TestDataReader.GetUserData("NumberOrder"));
        }
        public static User WithWrongDocumentNumber()
        {
            return new User(TestDataReader.GetUserData("Surname"), TestDataReader.GetUserData("Name"), TestDataReader.GetUserData("Patronymic"),
                 TestDataReader.GetUserData("Birthday"), "f1", TestDataReader.GetUserData("Email"), TestDataReader.GetUserData("NumberOrder"));
        }

        public static User WithWrongEmail()
        {
            return new User(TestDataReader.GetUserData("Surname"), TestDataReader.GetUserData("Name"), TestDataReader.GetUserData("Patronymic"),
                 TestDataReader.GetUserData("Birthday"), TestDataReader.GetUserData("Document"), "ivan-v-1971y@andex.by", TestDataReader.GetUserData("NumberOrder"));
        }
    }
}
