using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Lesson008
{
    class ViewModel : INotifyPropertyChanged
    {
        public string[] SourceTexts
        {
            get { return _SourceTexts; }
            set
            {
                if (_SourceTexts == value) return;
                _SourceTexts = value;
                OnPropertyChanged("SourceTexts");
                Filte();//源文本发生变化，立即刷选
            }
        }
        private string[] _SourceTexts;

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

        public string NoPattern
        {
            get { return _NoPattern; }
            set
            {
                if (_NoPattern == value) return;
                _NoPattern = value;
                OnPropertyChanged("NoPattern");
            }
        }
        private string _NoPattern;

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

        public void LoadSource(string aFileName)
        {
            SourceTexts = File.ReadAllLines(aFileName);
        }

        public void Filte()
        {
            StringBuilder aStringBuilder = new StringBuilder();
            /* if (string.IsNullOrWhiteSpace(Pattern))//为空时，输出所有值，不匹配
             {
                 foreach (string aLine in SourceTexts)
                     aStringBuilder.AppendLine(aLine);
             }
             else
             {
                 Regex aRegex = new Regex(Pattern);
                 foreach (string aLine in SourceTexts)
                 {
                     if (aRegex.IsMatch(aLine))
                         aStringBuilder.AppendLine(aLine);
                 }
             }
             ViewText = aStringBuilder.ToString();*/
            Regex aRegex = string.IsNullOrWhiteSpace(Pattern) ? null : new Regex(Pattern);
            Regex aNoRegex = string.IsNullOrWhiteSpace(NoPattern) ? null : new Regex(NoPattern);
            foreach (string aLine in SourceTexts)
            {
                if (aRegex != null && aRegex.IsMatch(aLine)) continue;
                if (aNoRegex != null && aNoRegex.IsMatch(aLine)) continue;
                aStringBuilder.AppendLine(aLine);
            }
            ViewText = aStringBuilder.ToString();
        }

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
