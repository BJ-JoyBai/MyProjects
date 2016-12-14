using System.ComponentModel;
using System.Xml.Linq;

namespace Lesson009
{
    class Contact : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public Contact()
        {

        }
        public Contact(XElement aXElement)
        {
            if (aXElement == null) return;
            Name = aXElement.Element("Name")?.Value;
            Mobile = aXElement.Element("Mobile")?.Value;
            Email = aXElement.Element("Email")?.Value;
        }


        private string _Name="无名";
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name == value) return;
                _Name = value;
                OnPropertyChanged("Name");
            }
        }

        private string _Mobile="不知道";
        public string Mobile
        {
            get { return _Mobile; }
            set
            {
                if (_Mobile == value) return;
                _Mobile = value;
                OnPropertyChanged("Mobile");
            }
        }

        private string _Email="不知道";
        public string Email
        {
            get { return _Email; }
            set
            {
                if (_Email == value) return;
                _Email = value;
                OnPropertyChanged("Email");
            }
        }

        public XElement CreateXElement(string aXmlNodeName)
        {
            return new XElement(aXmlNodeName,
                new XElement("Name", Name),
                new XElement("Mobile", Mobile),
                new XElement("Email", Email));
        }
    }
}
