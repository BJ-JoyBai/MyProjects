using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace Lesson008
{
    class ViewModel : INotifyPropertyChanged
    {
        public string[] SourceText
        {
            get { return _SourceText; }
            set
            {
                if (_SourceText == value) return;
                _SourceText = value;
                OnPropertyChanged("SourceText");
            }
        }
        private string[] _SourceText;

        public string Pattern
        {
            get { return _Pattern; }    
            set
            {
                if (_Pattern == value) return;
                _Pattern = value;
                OnPropertyChanged("Pattern");
            }
        }
        private string _Pattern;

        public string ViewText
        {
            get { return _ViewText; }
            set
            {
                if (_ViewText == value) return;
                _ViewText = value;
                OnPropertyChanged("ViewText");
            }
        }
        private string _ViewText;

        public void Filte()
        {
            StringBuilder aStringBuilder = new StringBuilder();
            Regex aRegex = new Regex(Pattern);
            foreach (string aLine in SourceText)
            {
                if (aRegex.IsMatch(aLine)) aStringBuilder.AppendLine(aLine);
            }
            ViewText = aStringBuilder.ToString();
        }

        private void OnPropertyChanged(string aPropertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName)); }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
