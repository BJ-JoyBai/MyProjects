using System;
using System.ComponentModel;
using System.Data.Linq;

namespace Lesson012
{
    class MainModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        private const string ConnectionString = @"Data Source=lenovo-PC\sqlexpress;Initial catalog=LingDemo001;Integrated Security=true";
        private MyDataDataContext _DataContext = new MyDataDataContext(ConnectionString);

        public bool DatabaseExist() => _DataContext.DatabaseExists();
        
        public void DeleteDatabase()
        {
            _DataContext.DeleteDatabase();
        }
        public void InitDatabase()
        {
           // if (_DataContext.DatabaseExists())
            //    throw new ApplicationException("数据库已经存在");
            _DataContext.CreateDatabase();
        }
        private Table<Contact> _Contacts;
        public Table<Contact> Contacts
        {
            get { return _Contacts; }
            set
            {
                if (_Contacts == value) return;
                _Contacts = value;
                OnPropertyChanged("Contacts");
            }
        }

        public void QueryContacts()
        {
            Contacts = _DataContext.Contact;
        }

        public void Submit()
        {
            _DataContext.SubmitChanges();
        }

        public void OOTest()
        {
            WorkContact aContact = new WorkContact();
            aContact.Name = "xxx";
            aContact.Company = "yyyy";
            Contacts.InsertOnSubmit(aContact);
            // var aWorkContacts = from r in Contacts where r is WorkContact select r;
            foreach (Contact aTargetContact in Contacts)//多态操作
                aTargetContact.ContactOperation();
        }
    }
}
