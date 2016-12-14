using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;

namespace Lesson009
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public ObservableCollection<Contact> Contacts { get; }
        public ViewModel()
        {
            Contacts = new ObservableCollection<Contact>();
            Load();
        }

        public void NewContact()
        {
            Contacts.Add(new Contact());
        }

        private const string FileName = "contacts.xml";

        public void Save()
        {
            XDocument aXDocument = new XDocument(new XElement("Contacts",from r in Contacts select r.CreateXElement("Contact")));
            aXDocument.Save(FileName);//保存，序列化
        }

        public void Load()
        {
            XDocument aXDocument = XDocument.Load(FileName);
            Contacts.Clear();
            foreach (XElement aXElement in aXDocument.Root.Elements("Contact"))
            {
                Contacts.Add(new Contact(aXElement));
            }
        }

        public void DeleteCantact(Contact aContact)
        {
            Contacts.Remove(aContact);
        }
    }
}
