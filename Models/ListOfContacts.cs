using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhonebookDB.ViewModel;

namespace PhonebookDB.Models
{
    public class ListOfContacts : ViewModelBase
    {

        private int _id;
        private string First_Name;
        private string Middle_Name;
        private string Last_Name;
        private string Phone_Number;
        private string _Gender;

        public int id { get { return _id; } set { _id = value; OnPropertyChanged("id"); } }
        public string FirstName { get { return First_Name; } set { First_Name = value; OnPropertyChanged("FirstName"); } }
        public string LastName { get { return Last_Name; } set { Last_Name = value; OnPropertyChanged("LastName"); } }
        public string MiddleName { get { return Middle_Name; } set { Middle_Name = value; OnPropertyChanged("MiddleName"); } }
        public string PhoneNumber { get { return Phone_Number; } set { Phone_Number = value; OnPropertyChanged("PhoneNumber"); } }
        public string Gender { get { return _Gender; } set { _Gender = value; OnPropertyChanged("Gender"); } }
    }
}


